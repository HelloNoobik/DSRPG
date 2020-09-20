using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.Hero
{
    public class Warrior : HeroBase
    {
        public Warrior(string name, string gender, string _class, string gift)
            :base(name, gender, _class)
        {
            strength = 10;
            agility = 5;
            stamina = 8;
            intellect = 2;


            health = 80;
            health = UpHealth();
            mana = 20;
            mana = UpMana();
            energy = 20;
            energy = UpEnergy();
            damage = 7;
            damage = UpDamage();
            armor = 0.07;
            armor = UpArmor();
        }

    }
}
