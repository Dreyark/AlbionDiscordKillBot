using AlbionKillboard;
using System;

public class Template
{
    //public int numberOfParticipants { get; set; }
    public int EventId { get; set; }
    public int TotalVictimKillFame { get; set; }
    public DateTime TimeStamp { get; set; }
    public Player Killer { get; set; }
    public Player Victim { get; set; }
    public int groupMemberCount { get; set; }
}
