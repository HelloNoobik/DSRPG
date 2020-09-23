using DSRPG.Classes.DataClasses;
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

            health = new Stat(100);
            mana = new Stat(50);
            energy = new Stat(20);
            damage = new Stat(10);
            armor = new StatDouble(0.09);

            CalcStats();

            Inv.AddItem("Сет Клирика", 1);
            Inv.AddItem("Кинжал", 1);
        }
    }
}
