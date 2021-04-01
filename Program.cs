using System;

namespace AlbionKillboard
{
    class Program
    {
        static void Main(string[] args)
        {
            string GuildToken = "GFQQHK9PQg288kf6Vpktow";
            Parser parse = new Parser();

            parse.LoadJsonGuildMembers(GuildToken);
            for (int i = 0; i < 1; i++)
            {
                string deathOrKill;
                if (i==0)
                {
                    deathOrKill = "deaths";
                }
                else
                {
                    deathOrKill = "kills";
                }
                foreach (string MemberToken in parse.MembersToken)
                {
                    parse.LoadJsonKillboard(MemberToken, deathOrKill);
                }
            }
        }
    }
}
