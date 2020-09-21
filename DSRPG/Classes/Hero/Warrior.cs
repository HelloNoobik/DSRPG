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
        public Warrior(string name, string gender, string _class, string gift)
            :base(name, gender, _class)
        {
            strength = 10;
            agility = 5;
            stamina = 8;
            intellect = 2;


            health = new Stat(80);
            mana = new Stat(20);
            energy = new Stat(20);
            damage = new Stat(7);
            armor = new StatDouble(0.07);

            CalcStats();

            inv.AddItem("Сет Воина", 1);
            inv.AddItem("Короткий меч", 1);
        }

    }
}
