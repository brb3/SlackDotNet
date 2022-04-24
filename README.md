SlackDotNet
===

[![.NET](https://github.com/brb3/SlackDotNet/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/brb3/SlackDotNet/actions/workflows/dotnet.yml)

*Note:* Currently this is very early and has limited functionality.

This library provides an interface for interacting with the Slack API.
Currently this provides a WebhookMessage model for use in data binding to requests from Slack.
Also, it provides the ability to post messages (and ephemeral messages) to slack.

## Usage

1. Add the latest version of the library to your project from [NuGet.org](https://www.nuget.org/packages/SlackDotNet)
2. In the `ConfigureServices()` method of your `Startup.cs`, call `services.AddSlackDotNet()` and pass in a `SlackConfig` object.
3. Add `ISlack` to your constructor where you want to use the library.
