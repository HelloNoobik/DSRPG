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
            health = UpHealth();
            mana = 0;
            mana = UpMana();
            energy = 0;
            energy = UpEnergy();
            damage = 0;
            damage = UpDamage();
            armor = 0;
            armor = UpArmor();
            strength = 0;
            agility = 0;
            stamina = 0;
            intellect = 0;
        }
    }
}
