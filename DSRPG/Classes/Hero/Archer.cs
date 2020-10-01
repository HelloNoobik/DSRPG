using DSRPG.Classes.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.Hero
{
    public class Archer:HeroBase
    {
        public Archer(string name,string gender, string gift) 
            : base(name,gender, gift)
        {
            strength = 8;
            agility = 15;
            stamina = 8;
            intellect = 4;
            Class = "Лучник";

            health = new Stat(80);
            mana = new Stat(50);
            energy = new Stat(50);
            damage = new Stat(5);
            armor = new StatDouble(0.05);

            CalcStats();


            Inv.SetItem("Сет Вора", 1);
            Inv.SetItem("Кинжал", 1);
        }

        public Archer() : base() 
        { 
        
        }
    }
}
