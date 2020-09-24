using DSRPG.Classes.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Core
{
    public class Statistics
    {
        public string Name;
        public int Kills;
        public int SoulsSpent;
        public int Progress;
        public int DeathCount;
        public int SoulsEarned;
        public int DamageGiven;
        public int DamageTaken;
        public int BossKills;

        public Statistics() 
        {
            Name = "";
            Kills = 999;
            SoulsSpent = 888;
            SoulsEarned = 777;
            Progress = 666;
            DeathCount = 555;
            DamageGiven = 444;
            DamageTaken = 333;
            BossKills = 222;
        }
    }
}
