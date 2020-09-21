using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.Hero
{
    public class Paladin : HeroBase
    {
        public Paladin(string name, string gender, string _class, string gift) 
            : base(name,gender,_class)
        {

            strength = 15;
            agility = 10;
            stamina = 10;
            intellect = 10;

            health = 100;
            health = UpHealth();
            mana = 50;
            mana = UpMana();
            energy = 20;
            energy = UpEnergy();
            damage = 10;
            damage = UpDamage();
            armor = 0.09;
            armor = UpArmor();

            inv.AddItem("Сет Клирика", 1);
            inv.AddItem("Кинжал", 1);
        }
    }
}
