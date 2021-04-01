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
        public List<string> MembersToken = new List<string>();
        public void LoadJsonGuildMembers(string guildToken)
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/guilds/" + guildToken + "/members/");
                JArray jsonArray = JArray.Parse(json);
                foreach (JObject result in jsonArray)
                {
                    MembersToken.Add(result["Id"].ToObject<string>());
                }
            }
        }
        public void LoadJsonKillboard(string playerToken, string deathOrKill)
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://gameinfo.albiononline.com/api/gameinfo/players/" + playerToken + "/"+ deathOrKill);
                JArray jsonArray = JArray.Parse(json);
                List<Template> templates = new List<Template>();
                foreach (JObject result in jsonArray)
                {
                    Template temp = new Template
                    {
                        TotalVictimKillFame = result["TotalVictimKillFame"].ToObject<int>(),
                        Killer = result["Killer"]["Name"].ToObject<string>(),
                        Victim = result["Victim"]["Name"].ToObject<string>()
                    };

                    templates.Add(temp);
                }
            }
        }
    }
}
