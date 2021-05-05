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
            //List<Member> memberList = new List<Member>();
            //List<Template> templates = new List<Template>();
            DiscordStartup discordStartup = new DiscordStartup();
            Killbot killbot = new Killbot();
            Thread discordTH;
            Thread killbotTH;
            discordTH = new Thread(discordStartup.MainAsync().GetAwaiter().GetResult);
            discordTH.Start();
            killbotTH = new Thread(() => killbot.bot(discordStartup));
            killbotTH.Start();
            //while(true)
        }

        //public void Killbot()
        //{
        //    Parser parse = new Parser();
        //    bool x = true;
        //    parse.LoadJsonGuildMembers(APIKeys.AlbionGuildToken, memberList);
        //    foreach (Member member in memberList)
        //    {
        //        member.Kills = new List<int>();
        //        member.Deaths = new List<int>();
        //        member.Kills.AddRange(parse.LoadJsonKillboard(member.Id, "kills"));
        //        member.Deaths.AddRange(parse.LoadJsonKillboard(member.Id, "deaths"));
        //    }
        //    while (x)
        //    {
        //        System.Threading.Thread.Sleep(30000);
        //        foreach (Member member in memberList)
        //        {
        //            List<int> newKills = new List<int>();
        //            List<int> newDeaths = new List<int>();
        //            List<int> killDiff = new List<int>();
        //            List<int> deathsDiff = new List<int>();
        //            newKills = parse.LoadJsonKillboard(member.Id, "kills");
        //            killDiff.AddRange(newKills.Except(member.Kills));
        //            newDeaths = parse.LoadJsonKillboard(member.Id, "deaths");
        //            deathsDiff.AddRange(newDeaths.Except(member.Deaths));
        //            member.Kills.Clear();
        //            member.Deaths.Clear();
        //            member.Kills.AddRange(newKills);
        //            member.Deaths.AddRange(newDeaths);

        //            foreach (int eventId in killDiff)
        //            {
        //                Template template = parse.LoadJsonEvent(eventId);
        //                System.Console.WriteLine("EventId: " + template.EventId);
        //                System.Console.WriteLine("Killer: " + template.Killer);
        //                System.Console.WriteLine("Victim: " + template.Victim);
        //                System.Console.WriteLine("Date: " + template.TimeStamp);
        //                templates.Add(template);
        //                //discordTH.

        //            }
        //            foreach (int eventId in deathsDiff)
        //            {
        //                Template template = parse.LoadJsonEvent(eventId);
        //                System.Console.WriteLine("EventId: " + template.EventId);
        //                System.Console.WriteLine("Killer: " + template.Killer);
        //                System.Console.WriteLine("Victim: " + template.Victim);
        //                System.Console.WriteLine("Date: " + template.TimeStamp);
        //                templates.Add(template);

        //            }

        //        }

        //    }
        //}
    }
}
