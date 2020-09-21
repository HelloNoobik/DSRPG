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
using DSRPG.Classes.DataClasses;

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
        protected Stat health;
        protected Stat mana;
        protected Stat energy;
        protected int strength;
        protected int agility;
        protected int stamina;
        protected int intellect;
        protected double armor;
        protected int damage;
        public Inventory inv;

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
        public Stat Health
        {
            get { return health; }
            set { health = value; OnPropertyChanged(); }
        }
        public Stat Mana
        {
            get { return mana; }
            set { mana = value; OnPropertyChanged(); }
        }
        
        public Stat Energy
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
            inv = new Inventory();
            inv.AddItem("Эстус", 3);
            Name = name;
            Class = _class;
            Gender = gender;
        }


        public void CalcStats()
        {
            health.Max = health.Max + (stamina * 5);
            mana.Max = mana.Max + (intellect * 5);
            if(agility % 3 == 0)
            {
                energy.Max = energy.Max + (agility * 1);
            }
            else
            {
                energy.Max = energy.Max + agility;
            }
            damage = damage + (strength / 4);
            armor = armor + (strength * 0.1) / 100;
            health.Reset();
            mana.Reset();
            energy.Reset();

        }
        public bool CheckDie()
        {
            if (health.Current == 0)
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
            if (mana.Current == 0) return true;
            else return false;
        } // чек на отсуствие маны



        public override string ToString() //Мож пойже пригодится
        {
            return base.ToString();
        }
    }
}
