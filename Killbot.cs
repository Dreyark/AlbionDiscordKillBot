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
        private List<Template> tempList = new List<Template>();
        public void Bot(DiscordStartup discordStartup)
        {
            Parser parse = new Parser();

            bool x = true;
            while (x)
            {
                tempList.AddRange(parse.LoadJsonEvents(eventList));
                if (eventList.Count >= 600)
                {
                    eventList.RemoveRange(0, 400);
                }
                System.Threading.Thread.Sleep(2000);
            }
        }

        public void SendImage(DiscordStartup discordStartup)
        {
            bool x = true;
            while (x)
            {
                foreach (Template t in tempList.ToArray())
                {
                    KillboardImage killboardImage = new KillboardImage();

                    if (killboardImage.EquipmentImage(t))
                        discordStartup.SendKillboard(t);

                    if (t.Victim.Inventory != null && t.Victim.Inventory.Any(s => s != null))
                    {
                        if (killboardImage.InventoryImage(t))
                            discordStartup.SendInventory(t);
                    }

                    System.Threading.Thread.Sleep(5000);
                    tempList.Remove(t);
                }
            }
        }
    }
}
