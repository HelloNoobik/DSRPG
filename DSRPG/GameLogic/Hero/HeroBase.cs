using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DSRPG.GameLogic.Hero
{
    public abstract class HeroBase
    {
        protected string name;
        protected int health;
        protected int mana;
        protected int energy;
        protected int strength;
        protected int agility;
        protected int stamina;
        protected int intellect;
        protected double armor;
        protected int damage;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }
        
        public int Energy
        {
            get { return energy; }
            set { energy = value; }
        }
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }
        public int Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }
        public int Intellect
        {
            get { return intellect; }
            set { intellect = value; }
        }
        public double Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }


        public int UpHealth()
        {
            health = health + (stamina * 5);
            return health;
        } // хп больше от стамины
        public int UpMana()
        {
            mana = mana + (intellect * 5);
            return mana;
        } // маны больше от интелекта

        public int UpEnergy()
        {
            if(agility % 3 == 0)
            {
                energy = energy + (agility * 1);
            }
            return energy;
        } // если число кратно 3 а то есть каждые 3 очка повышается энергия от ловкости

        public int UpDamage()
        {
            if(strength % 2 == 0)
            {
                damage = damage + (strength * 1);
            }
            return damage;
        } // если число кратно 2 а то есть каждые 2 очка повышается дамага от силы

        public double UpArmor()
        {
            armor = armor + ((strength * 0.1)/100);
            return armor;
        }  // повышение армора от силы 
        public bool CheckDie()
        {
            if (health == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }  // чек на смерть
        public bool CheckNoneMana()
        {
            if (mana == 0) return true;
            else return false;
        } // чек на отсуствие маны
        
        public void CheckResist()
        {
          // int reset = damagemob * (1-(armor/100));
        } // доделать 

        
        public override string ToString() //Мож пойже пригодится
        {
            return base.ToString();
        }
    }
}
