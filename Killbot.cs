using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbionKillboard
{
    class Killbot
    {
        List<int> eventList = new List<int>();
        public void bot(DiscordStartup discordStartup)
        {
            Parser parse = new Parser();
            bool x = true;
            //parse.LoadJsonGuildMembers(APIKeys.AlbionGuildToken, memberList);
            //foreach (Member member in memberList)
            //{
            //    //member.Kills = new List<int>();
            //    //member.Deaths = new List<int>();
            //    //member.Kills.AddRange(parse.LoadJsonKillboard(member.Id, "kills"));
            //    //member.Deaths.AddRange(parse.LoadJsonKillboard(member.Id, "deaths"));
            //}
            while (x)
            {
                List<Template> tempList = parse.LoadJsonEvents(eventList);
                //List<Template> templates = new List<Template>();
                //foreach (Member member in memberList)
                //{
                //    List<string> published = new List<string>();
                //    List<int> newKills = new List<int>();
                //    List<int> newDeaths = new List<int>();
                //    List<int> killDiff = new List<int>();
                //    List<int> deathsDiff = new List<int>();
                //    newKills = parse.LoadJsonKillboard(member.Id, "kills");
                //    newDeaths = parse.LoadJsonKillboard(member.Id, "deaths");
                //    if (newKills.Count == member.Kills.Count)
                //    {
                //        killDiff.AddRange(newKills.Except(member.Kills));
                //        member.Kills.Clear();
                //        member.Kills.AddRange(newKills);
                //    }
                //    if (newDeaths.Count == member.Deaths.Count)
                //    {
                //        deathsDiff.AddRange(newDeaths.Except(member.Deaths));
                //        member.Deaths.Clear();
                //        member.Deaths.AddRange(newDeaths);
                //    }
                //    foreach (int eventId in killDiff)
                //    {
                //        Template template = parse.LoadJsonEvent(eventId);
                //        System.Console.WriteLine("EventId: " + template.EventId);
                //        System.Console.WriteLine("Killer: " + template.Killer);
                //        System.Console.WriteLine("Victim: " + template.Victim);
                //        System.Console.WriteLine("Date: " + template.TimeStamp);
                //        if (template.EventId != 0)
                //        {
                //            templates.Add(template);
                //        }

                //    }
                //    foreach (int eventId in deathsDiff)
                //    {
                //        Template template = parse.LoadJsonEvent(eventId);
                //        System.Console.WriteLine("EventId: " + template.EventId);
                //        System.Console.WriteLine("Killer: " + template.Killer);
                //        System.Console.WriteLine("Victim: " + template.Victim);
                //        System.Console.WriteLine("Date: " + template.TimeStamp);
                //        if (template.EventId != 0)
                //        {
                //            templates.Add(template);
                //        }

                //    }
                //tempList = (List<Template>)tempList.OrderByDescending(s => s.TimeStamp);
                discordStartup.Message(tempList);
                //}
                if(eventList.Count >= 300)
                {
                    eventList.RemoveRange(0, 200);
                }
                System.Threading.Thread.Sleep(3000);
            }
        }
    }
}
