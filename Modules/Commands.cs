using Discord.Commands;
using Discord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace AlbionKillboard.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("pong");
        }

        private async Task abc(DiscordSocketClient _client)
        {
            ulong id = 521066763589386240;
            var chnl = _client.GetChannel(id) as IMessageChannel;
            await chnl.SendMessageAsync("Announcement!");
        }
    }
}
