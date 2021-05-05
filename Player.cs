using System;
using System.Collections.Generic;
using System.Text;

namespace AlbionKillboard
{
    public class Player
    {
        public int AverageItemPower { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string GuildName { get; set; }
        public Equipment Equipment { get; set; }
        public Item[] Inventory { get; set; }
    }
}
