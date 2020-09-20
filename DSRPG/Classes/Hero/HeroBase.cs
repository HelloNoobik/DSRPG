using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DSRPG.Classes.Hero
{
    public abstract class HeroBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected string name;
        protected string _class;
        protected string gender;
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
            set { name = value; OnPropertyChanged(); }
        }

        public string Class
        {
            get { return _class; }
            set { _class = value; OnPropertyChanged(); }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(); }
        }
        public int Health
        {
            get { return health; }
            set { health = value; OnPropertyChanged(); }
        }
        public int Mana
        {
            get { return mana; }
            set { mana = value; OnPropertyChanged(); }
        }
        
        public int Energy
        {
            get { return energy; }
            set { energy = value; OnPropertyChanged(); }
        }
        public int Strength
        {
            get { return strength; }
            set { strength = value; OnPropertyChanged(); }
        }
        public int Agility
        {
            get { return agility; }
            set { agility = value; OnPropertyChanged(); }
        }
        public int Stamina
        {
            get { return stamina; }
            set { stamina = value; OnPropertyChanged(); }
        }
        public int Intellect
        {
            get { return intellect; }
            set { intellect = value; OnPropertyChanged(); }
        }
        public double Armor
        {
            get { return armor; }
            set { armor = value; OnPropertyChanged(); }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; OnPropertyChanged(); }
        }

        public HeroBase(string name, string gender, string _class) 
        {
            Name = name;
            Class = _class;
            Gender = gender;
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
            else
            {
                energy = energy + agility;
            }
            return energy;
        } // если число кратно 3 а то есть каждые 3 очка повышается энергия от ловкости

        public int UpDamage()
        {
            damage = damage + (strength/4);
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
                MessageBox.Show("Вы умерли");
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
        

        
        public override string ToString() //Мож пойже пригодится
        {
            return base.ToString();
        }
    }
}
