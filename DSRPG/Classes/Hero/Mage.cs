using DSRPG.Classes.DataClasses;
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


            health = new Stat(60);
            mana = new Stat(100);
            energy = new Stat(20);
            damage = 6;
            armor = 0.03;

            CalcStats();

            inv.AddItem("Сет Волшебника", 1);
            inv.AddItem("Кинжал", 1);
        }
    }
}
