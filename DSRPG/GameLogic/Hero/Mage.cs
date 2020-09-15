using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.GameLogic.Hero
{
    public class Mage:HeroBase
    {
        public Mage()
            : base()
        {
            name = "";
            health = 0;
            mana = 0;
            strength = 0;
            agility = 0;
            stamina = 0;
            intellect = 0;
            armor = 0;
        }
    }
}
