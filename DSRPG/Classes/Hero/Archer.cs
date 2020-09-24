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
        public Archer(string name,string gender, string _class, string gift) 
            : base(name,gender,_class)
        {
            strength = 8;
            agility = 0;
            stamina = 8;
            intellect = 5;


            health = new Stat(60);
            mana = new Stat(60);
            energy = new Stat(50);
            damage = new Stat(13);
            armor = new StatDouble(0.05);

            CalcStats();


            Inv.AddItem("Сет Вора", 1);
            Inv.AddItem("Кинжал", 1);
        }
    }
}
