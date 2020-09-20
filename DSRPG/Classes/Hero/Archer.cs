using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.Hero
{
    public class Archer:HeroBase
    {
        public Archer(string name,string gender, string _class, string gift) 
            : base(name,gender,_class)
        {
            strength = 8;
            agility = 8;
            stamina = 8;
            intellect = 5;


            health = 60;
            health = UpHealth();
            mana = 60;
            mana = UpMana();
            energy = 20;
            energy = UpEnergy();
            damage = 13;
            damage = UpDamage();
            armor = 0.05;
            armor = UpArmor();
        }
    }
}
