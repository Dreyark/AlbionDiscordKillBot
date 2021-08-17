using AlbionKillboard.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AlbionKillboard
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscordStartup discordStartup = new DiscordStartup();
            Killbot killbot = new Killbot();
            Thread discordTH;
            Thread killBotTH;
            Thread sendBotTH;
            discordTH = new Thread(discordStartup.MainAsync().GetAwaiter().GetResult);
            discordTH.Start();
            // killbotTH = new Thread(() => killbot.Bot(discordStartup));
            killBotTH = new Thread(()=> killbot.Bot((discordStartup)));
            sendBotTH = new Thread(() => killbot.SendImage(discordStartup));
            killBotTH.Start();
            sendBotTH.Start();
        }
    }
}
