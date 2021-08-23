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
        public List<Template> LoadJsonEvents(List<int> eventList)
        {
            List<Template> tempList = new List<Template>();
            try
            {
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/events?limit=51&offset=0");
                    JArray jsonArray = JArray.Parse(json);
                    foreach (JObject x in jsonArray)
                    {
                        if (!eventList.Contains(x["EventId"].ToObject<int>()))
                        {
                            Template temp = new Template();
                            temp = x.ToObject<Template>();
                            
                            if (temp.Killer.GuildId == APIKeys.AlbionGuildToken || temp.Victim.GuildId ==
                                APIKeys.AlbionGuildToken)
                            {
                                tempList.Add(temp);
                                eventList.Add(temp.EventId);
                            }
                        }
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
