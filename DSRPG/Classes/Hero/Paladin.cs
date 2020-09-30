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

            strength = 10;
            agility = 10;
            stamina = 10;
            intellect = 5;

            health = new Stat(80);
            mana = new Stat(50);
            energy = new Stat(50);
            damage = new Stat(5);
            armor = new StatDouble(0.05);

            CalcStats();

            Inv.AddItem("Сет Клирика", 1);
            Inv.AddItem("Кинжал", 1);
        }

        public Paladin() : base() 
        { 
        
        }
    }
}
