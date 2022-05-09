using Newtonsoft.Json;
using SlackDotNet.Models.Messages;
using SlackDotNet.Models.Messages.Payloads.EventsAPI;
using Xunit;

namespace SlackDotNet.Test.Models.Messages;

public class EventsAPIMessageTest
{
    [Fact]
    public void GetsPayloadForDifferentEventTypes()
    {
        // Test data for AppHomeOpened
        var aho = new AppHomeOpened()
        {
            Type = "app_home_opened",
            ChannelId = "123456",
        };
        var appHomeOpenedEventJson = JsonConvert.SerializeObject(new
        {
            type = "events_api",
            payload = aho,
        });

        // Test data for StarAdded
        var sa = JsonConvert.SerializeObject(new StarAdded()
        {
            Type = "star_added",
            User = "123456",
        });
        var starAddedEventJson = JsonConvert.SerializeObject(new
        {
            type = "star_added",
            payload = sa,
        });

        // Test AppHomeOpened
        var ahoEvent = JsonConvert.DeserializeObject<EventsAPIMessage>(appHomeOpenedEventJson);

        Assert.IsType<EventsAPIMessage>(ahoEvent);
        Assert.IsType<AppHomeOpened>(ahoEvent!.Payload);
    }
}

public class SlashCommandTest
{
    [Fact]
    public void TestSlashCommand()
    {
        var message = JsonConvert.SerializeObject(new
        {
            type = "slash_commands",
            envelope_id = "asdfasdfasdfasdf",
            accepts_response_payload = true,
            payload = new
            {
                token = "asdfasdfasdfasdf",
                team_id = "T1234567890",
                team_domain = "slackdotnet",
                channel_id = "asdfasdfasdf"
            }
        });

        var slashCommandMessage = JsonConvert.DeserializeObject<SlashCommandMessage>(message);

        Assert.IsType<SlashCommandMessage>(slashCommandMessage);
    }
}
