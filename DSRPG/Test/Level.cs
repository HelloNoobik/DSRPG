using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSRPG.Classes;
using DSRPG.Classes.Hero;

namespace DSRPG.Test
{ 
    public class Level
    {
        List<Mobsbase> mobs = new List<Mobsbase>();
        HeroBase hero;

        private int deadMobsCount = 0;

        public delegate void Event();

        public event Event AllMobsDead;

        private int DeadMobsCount
        {
            get { return deadMobsCount; }
            set 
            {
                deadMobsCount = value;
                if(deadMobsCount == mobs.Count)
                {
                    AllMobsDead?.Invoke();
                }
            }
        }

        public Level()
        {
            
        }
    }
}
