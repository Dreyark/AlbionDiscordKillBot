using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

namespace AlbionKillboard
{
    class Parser
    {
        public List<string> membersToken = new List<string>();
        public void LoadJsonGuildMembers(string guildToken, List<Member> memberList)
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/guilds/" + guildToken + "/members/");
                JArray jsonArray = JArray.Parse(json);
                foreach (JObject result in jsonArray)
                {
                    Member member = new Member();
                    member.Nick = result["Name"].ToObject<string>();
                    member.Id = result["Id"].ToObject<string>();
                    memberList.Add(member);
                }
            }
        }
        public List<int> LoadJsonKillboard(string playerToken, string deathOrKill)
        {
            List<int> EventsId = new List<int>();
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/players/" + playerToken + "/" + deathOrKill);
                JArray jsonArray = JArray.Parse(json);
                foreach (JObject result in jsonArray)
                {
                    EventsId.Add(result["EventId"].ToObject<int>());
                }
                return EventsId;
            }
        }

        public Template LoadJsonEvent(int eventId)
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/events/" + eventId);
                JArray jsonArray = JArray.Parse(json);
                JObject jsonObject = JObject.Parse(json);
                    Template temp = new Template
                    {

                        TotalVictimKillFame = jsonObject["TotalVictimKillFame"].ToObject<int>(),
                        Killer = jsonObject["Killer"]["Name"].ToObject<string>(),
                        Victim = jsonObject["Victim"]["Name"].ToObject<string>(),
                        EventId = jsonObject["EventId"].ToObject<int>(),
                        groupMemberCount = jsonObject["groupMemberCount"].ToObject<int>(),
                        TimeStamp = jsonObject["TimeStamp"].ToObject<DateTime>()
                    };
                return temp;
            }
        }
    }
}
