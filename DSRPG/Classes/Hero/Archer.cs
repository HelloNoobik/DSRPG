﻿using System;
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
            health = 0;
            health = UpHealth();
            mana = 0;
            mana = UpMana();
            energy = 0;
            energy = UpEnergy();
            damage = 0;
            damage = UpDamage();
            armor = 0;
            armor = UpArmor();
            strength = 0;
            agility = 0;
            stamina = 0;
            intellect = 0;
        }
    }
}
