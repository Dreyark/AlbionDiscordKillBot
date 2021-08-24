using System;
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
        static readonly string StartupPath = Environment.CurrentDirectory;
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

        public void SendKillboard(Template template)
        {
            ulong id = 824551134849007666;
            var chnl = _client.GetChannel(id) as IMessageChannel;
            chnl.SendFileAsync("Kill.png");
        }
        public void SendInventory(Template template)
        {
            ulong id = 824551134849007666;
            var chnl = _client.GetChannel(id) as IMessageChannel;
            chnl.SendFileAsync("inventory.png");
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
