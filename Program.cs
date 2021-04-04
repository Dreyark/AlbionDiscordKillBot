using System;
using System.Collections.Generic;
using System.Linq;

namespace AlbionKillboard
{
    class Program
    {
        static void Main(string[] args)
        {
            bool x = true;
            List<Member> memberList = new List<Member>();
            string GuildToken = "GFQQHK9PQg288kf6Vpktow";
            Parser parse = new Parser();

            parse.LoadJsonGuildMembers(GuildToken, memberList);
            foreach (Member member in memberList)
            {
                //member.Kills = new List<int>();
                //member.Deaths = new List<int>();
                member.Kills = parse.LoadJsonKillboard(member.Id, "kills");
                member.Deaths = parse.LoadJsonKillboard(member.Id, "deaths");
            }
            while (x)
            {
                foreach (Member member in memberList)
                {
                    List<int> diff = new List<int>();
                    diff = parse.LoadJsonKillboard(member.Id, "kills");
                    var killDiff = diff.Except(member.Kills);
                    member.Kills = diff;
                    diff = parse.LoadJsonKillboard(member.Id, "deaths");
                    var deathsDiff = diff.Except(member.Deaths);
                    member.Deaths = diff;

                    foreach (int eventId in killDiff)
                    {
                        parse.LoadJsonEvent(eventId);

                    }
                    foreach (int eventId in deathsDiff)
                    {
                        parse.LoadJsonEvent(eventId);

                    }

                }

            }
        }
    }
}
