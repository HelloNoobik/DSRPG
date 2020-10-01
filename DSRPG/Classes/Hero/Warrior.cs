using DSRPG.Classes.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.Hero
{
    public class Warrior : HeroBase
    {
        public Warrior(string name, string gender, string gift)
            :base(name, gender, gift)
        {
            strength = 8;
            agility = 5;
            stamina = 8;
            intellect = 0;
            Class = "Воин";

            health = new Stat(80);
            mana = new Stat(50);
            energy = new Stat(50);
            damage = new Stat(5);
            armor = new StatDouble(0.05);

            CalcStats();

            Inv.SetItem("Сет Воина", 1);
            Inv.SetItem("Короткий меч", 1);
        }

        public Warrior() : base() 
        { 
        
        }
    }
}
