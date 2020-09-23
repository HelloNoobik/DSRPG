﻿using GalaSoft.MvvmLight.Messaging;
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
        protected StatDouble armor;
        protected Stat damage;
        public Inventory inv;
        private int estusCount = 3;
        private int souls = 10000000;

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
        public StatDouble Armor
        {
            get { return armor; }
            set { armor = value; OnPropertyChanged(); }
        }
        public Stat Damage
        {
            get { return damage; }
            set { damage = value; OnPropertyChanged(); }
        }

        public int Souls 
        {
            get { return souls; }
            set { souls = value; OnPropertyChanged(); }
        }

        public HeroBase(string name, string gender, string _class) 
        {
            inv = new Inventory();
            inv.AddItem("Эстус", 3);
            Name = name;
            Class = _class;
            Gender = gender;

            inv.WeaponChanged += Inv_WeaponChanged;
            inv.ArmorChanged += Inv_ArmorChanged;
        }

        private void Inv_ArmorChanged()
        {
            armor.Max = armor.Base;
            Armor item = inv.GetItem(inv.Armor) as Armor;
            armor.Max = armor.Base + item.Defence;
            armor.Reset();
        }

        private void Inv_WeaponChanged()
        {
            damage.Max = damage.Base;
            Weapon item = inv.GetItem(inv.Weapon) as Weapon;
            damage.Max = damage.Base + item.Damage;
            damage.Reset();
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
            damage.Max += (strength / 4);
            armor.Max += (strength * 0.1) / 100;

            damage.FullReset();
            armor.FullReset();
            health.FullReset();
            mana.FullReset();
            energy.FullReset();

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

        public void Rest() 
        {
            if (inv.GetItem(0).Count < estusCount) 
            {
                inv.AddItem("Эстус", estusCount - inv.GetItem(0).Count);
            }

            Health.Reset();
            Mana.Reset();
            Energy.Reset();
        }

        public override string ToString() //Мож пойже пригодится
        {
            return base.ToString();
        }
    }
}
