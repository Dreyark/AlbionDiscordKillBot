using System;
using System.Collections.Generic;
using System.Text;

namespace AlbionKillboard
{
    class Member
    {
        public string Id { get; set; }
        public string Nick { get; set; }
        public List<int> Kills { get; set; }
        public List<int> Deaths { get; set; }
    }
}
