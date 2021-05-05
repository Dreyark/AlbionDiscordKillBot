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
        //public List<string> membersToken = new List<string>();
        //public void LoadJsonGuildMembers(string guildToken, List<Member> memberList)
        //{
        //    try
        //    {
        //        using (var webClient = new WebClient())
        //        {
        //            var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/guilds/" + guildToken + "/members/");
        //            JArray jsonArray = JArray.Parse(json);
        //            foreach (JObject result in jsonArray)
        //            {
        //                Member member = new Member();
        //                member.Nick = result["Name"].ToObject<string>();
        //                member.Id = result["Id"].ToObject<string>();
        //                memberList.Add(member);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
        //public List<int> LoadJsonKillboard(string playerToken, string deathOrKill)
        //{
        //    List<int> EventsId = new List<int>();
        //    try
        //    {
        //        using (var webClient = new WebClient())
        //        {
        //            var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/players/" + playerToken + "/" + deathOrKill);
        //            JArray jsonArray = JArray.Parse(json);
        //            foreach (JObject result in jsonArray)
        //            {
        //                EventsId.Add(result["EventId"].ToObject<int>());
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return EventsId;
        //}

        //public Template LoadJsonEvent(int eventId)
        //{
        //    Template temp = new Template();
        //    try
        //    {
        //        using (var webClient = new WebClient())
        //        {
        //            var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/events/" + eventId);
        //            //JArray jsonArray = JArray.Parse(json);
        //            JObject jsonObject = JObject.Parse(json);
        //            //Template temp = new Template
        //            //{

        //            temp.TotalVictimKillFame = jsonObject["TotalVictimKillFame"].ToObject<int>();
        //            temp.Killer = jsonObject["Killer"]["Name"].ToObject<string>();
        //            temp.Victim = jsonObject["Victim"]["Name"].ToObject<string>();
        //            temp.EventId = jsonObject["EventId"].ToObject<int>();
        //            temp.groupMemberCount = jsonObject["groupMemberCount"].ToObject<int>();
        //            temp.TimeStamp = jsonObject["TimeStamp"].ToObject<DateTime>();
        //            //};
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return temp;
        //}

        public List<Template> LoadJsonEvents(List<int> eventList)
        {
            List<Template> tempList = new List<Template>();
            try
            {
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/events/");
                    JArray jsonArray = JArray.Parse(json);
                    foreach (JObject x in jsonArray)
                    {
                        //if (x["Killer"]["GuildId"].ToObject<string>() == APIKeys.AlbionGuildToken ||
                        //    x["Victim"]["GuildId"].ToObject<string>() == APIKeys.AlbionGuildToken)
                        //{
                        if (!eventList.Contains(x["EventId"].ToObject<int>()))
                        {
                            Template temp = new Template();
                            temp = x.ToObject<Template>();
                            //temp.Killer = x["Killer"].ToObject<Player>();
                            //temp.Victim= x["Victim"].ToObject<Player>();
                            //temp.EventId = x["EventId"].ToObject<int>();
                            //temp.groupMemberCount = x["groupMemberCount"].ToObject<int>();
                            //temp.TimeStamp = x["TimeStamp"].ToObject<DateTime>();
                            tempList.Add(temp);
                            eventList.Add(temp.EventId);
                        }
                        //}
                    }
                }
            }
            catch
            {

            }
            return tempList;
        }
    }
}
