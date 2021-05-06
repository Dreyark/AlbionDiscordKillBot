using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AlbionKillboard
{
    class DiscordStartup
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();

            _client.Log += Log;

            await RegisterCommandsAsync();
            //_client.GetGuild(455129120486195230);
            await _client.LoginAsync(TokenType.Bot, APIKeys.DiscordToken);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix("!", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                if (result.Error.Equals(CommandError.UnmetPrecondition)) await message.Channel.SendMessageAsync(result.ErrorReason);
            }
        }

        public void Message(Template template)
        {
            //System.Console.WriteLine(_client.Status.ToString());
            //foreach (Template template in templates)
            //{
                //string message = "EventId: " + template.EventId + " Killer: " + template.Killer + " Victim: " + template.Victim + " Time: " + template.TimeStamp;
                ulong id = 521066763589386240;
                var chnl = _client.GetChannel(id) as IMessageChannel;
                chnl.SendFileAsync(@"C:\Users\Dreyark\Desktop\path_to_your_file.png");
                //chnl.SendMessageAsync(message);
            //}
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
