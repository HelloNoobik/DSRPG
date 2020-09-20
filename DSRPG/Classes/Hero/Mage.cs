using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.Hero
{
    public class Mage:HeroBase
    {
        public Mage(string name, string gender, string _class, string gift)
            : base(name, gender, _class)
        {

            strength = 4;
            agility = 4;
            stamina = 4;
            intellect = 12;


            health = 60;
            health = UpHealth();
            mana = 100;
            mana = UpMana();
            energy = 20;
            energy = UpEnergy();
            damage = 6;
            damage = UpDamage();
            armor = 0.03;
            armor = UpArmor();
        }
    }
}
