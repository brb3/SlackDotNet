using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using WebSocketExtensions;

namespace SlackDotNet
{
    /// <summary>
    /// This wraps the System.Net.WebSockets client. Most of this is taken from the
    /// github.com/maxfridbe/websocketextensions project and altered to expose the Client information.
    /// The license of that project is below:
    ///
    /// MIT License
    ///
    /// Copyright (c) 2018 maxfridbe

    /// Permission is hereby granted, free of charge, to any person obtaining a copy
    /// of this software and associated documentation files (the "Software"), to deal
    /// in the Software without restriction, including without limitation the rights
    /// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    /// copies of the Software, and to permit persons to whom the Software is
    /// furnished to do so, subject to the following conditions:

    /// The above copyright notice and this permission notice shall be included in all
    /// copies or substantial portions of the Software.

    /// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    /// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    /// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    /// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    /// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    /// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    /// SOFTWARE.
    /// </summary>
    internal class WebSocketWrapper : IDisposable
    {
        public bool Connected { get; set; } = false;
        public Action<StringMessageReceivedEventArgs> MessageHandler { get; set; } = (e) => { };
        public Action<BinaryMessageReceivedEventArgs> BinaryHandler { get; set; } = (e) => { };
        public Action<WebSocketReceivedResultEventArgs> CloseHandler { get; set; } = (e) => { };
        public Action<ClientWebSocketOptions> ConfigureOptionsBeforeConnect { get; set; } = (e) => { };

        private ClientWebSocket _client;
        public Guid ClientId;
        private Task _incomingMessagesTask;
        private PagingMessageQueue _messageQueue;
        private Action<WebSocketReceivedResultEventArgs> _closeBehavior;
        private long _receiveQueueLimitBytes = long.MaxValue;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private bool _disposing = false;
        private readonly Action<string, bool> _logger;

        public WebSocketWrapper(Action<string, bool> logger = null, Guid? clientId = null, long receiveQueueLimitBytes = long.MaxValue)
        {
            _logger = logger;
            ClientId = clientId ?? Guid.NewGuid();
            _receiveQueueLimitBytes = receiveQueueLimitBytes;
        }

        public async Task ConnectAsync(string url, CancellationToken tok = default(CancellationToken))
        {
            _client = new ClientWebSocket();
            ConfigureOptionsBeforeConnect(_client.Options);

            await _client.ConnectAsync(new Uri(url), tok);

            var messageBehavior = MakeSafe(MessageHandler, "MessageHandler");
            var binaryBehavior = MakeSafe(BinaryHandler, "BinaryHandler");
            _closeBehavior = MakeSafe(CloseHandler, "CloseHandler");

            _messageQueue = new PagingMessageQueue("WebSocketClient", _logError, _receiveQueueLimitBytes);

            _incomingMessagesTask = Task.Factory.StartNew(async () => await _client.ProcessIncomingMessages(_messageQueue, ClientId, messageBehavior, binaryBehavior, _closeBehavior, _logInfo, _cancellationTokenSource.Token));
        }

        public Action<T> MakeSafe<T>(Action<T> toRun, string handlerName)
        {
            return new Action<T>((T data) =>
            {
                try
                {
                    toRun(data);
                }
                catch (Exception e)
                {
                    _logError($"Error in handler '{handlerName}': {e}");
                }
            });
        }

        public Task SendStringAsync(string data, CancellationToken tok = default(CancellationToken))
        {
            return _client.SendStringAsync(data, tok);
        }

        public Task SendBytesAsync(byte[] data, CancellationToken tok = default(CancellationToken))
        {
            return _client.SendBytesAsync(data, tok);

        }
        public Task SendStreamAsync(Stream data, bool dispose = true, CancellationToken tok = default(CancellationToken))
        {
            return _client.SendStreamAsync(data, dispose, tok);
        }

        public void Dispose()
        {
            if (_disposing)
                return;

            _disposing = true;

            if (_client.State == WebSocketState.Open)
            {
                try
                {
                    _client.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "Client Closing", CancellationToken.None).GetAwaiter().GetResult();
                }
                catch (Exception e)
                {
                    if (_client.State != WebSocketState.Aborted)
                        _logError($"Trying to close connection in dispose exception {e} {e.StackTrace}");
                }

                _closeBehavior(new WebSocketReceivedResultEventArgs(WebSocketCloseStatus.NormalClosure, "Closed because disposing"));
            }

            _client.CleanupSendMutex();

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();

            if (_incomingMessagesTask != null)
            {
                _incomingMessagesTask.GetAwaiter().GetResult();
                _messageQueue.CompleteAdding();
            }

            _client.Dispose();
        }

        private void _logInfo(string msg)
        {
            _logger?.Invoke(msg, false);
        }

        private void _logError(string msg)
        {
            _logger?.Invoke(msg, true);
        }
    }
}
