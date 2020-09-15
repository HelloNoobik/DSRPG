using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DSRPG.GameLogic.Hero
{
    public abstract class HeroBase
    {
        protected string name;
        protected int health;
        protected int mana;
        protected int strength;
        protected int agility;
        protected int stamina;
        protected int intellect;
        protected int armor;

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }
        public int Health
        {
            get { return health; }
            protected set { health = value; }
        }
        public int Mana
        {
            get { return mana; }
            protected set { mana = value; }
        }
        public int Strength
        {
            get { return strength; }
            protected set { strength = value; }
        }
        public int Agility
        {
            get { return agility; }
            protected set { agility = value; }
        }
        public int Stamina
        {
            get { return stamina; }
            protected set { stamina = value; }
        }
        public int Intellect
        {
            get { return intellect; }
            protected set { intellect = value; }
        }
        public int Armor
        {
            get { return armor; }
            protected set { armor = value; }
        }

        protected HeroBase()
        {
            Name = name;
            Health = health;
            Mana = mana;
            Strength = strength;
            Agility = agility;
            Stamina = stamina;
            Intellect = intellect;
            Armor = armor;
        }
        
        public override string ToString() //Мож пойже пригодится
        {
            return base.ToString();
        }
    }
}
