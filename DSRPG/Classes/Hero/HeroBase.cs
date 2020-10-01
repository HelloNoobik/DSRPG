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
        protected StatDouble armor;
        protected Stat damage;
        public Inventory Inv;
        private int estusCount = 3;
        private int souls = 1000;

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
            set 
            {
                health = value; OnPropertyChanged();
            }
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
        public string ArmorStr
        {
            get { return $"{armor.Max * 100} %"; }
        }
        public Stat Damage
        {
            get { return damage; }
            set { damage = value; OnPropertyChanged(); }
        }

        public int EstusCount 
        {
            get { return estusCount; }
            set { estusCount = value; }
        }

        public int Souls 
        {
            get { return souls; }
            set 
            {
                if(souls > value)
                {
                    int soul = souls - value;
                    Core.Settings.Stats.SoulsSpent += soul;
                }
                else
                {
                    int soul = value - souls;
                    Core.Settings.Stats.SoulsEarned++;
                }
                souls = value; OnPropertyChanged();
            }
        }

        public HeroBase(string name, string gender, string gift) 
        {
            Inv = new Inventory();
            Inv.SetItem("Эстус", 3);
            Name = name;
            Gender = gender;

            switch (gift) 
            {
                case "Души":
                    Inv.SetItem("Душа безымянного солдата", 2);
                    break;
                case "Человечность":
                    Inv.SetItem("Человечность", 1);
                    break;
                case "Бомбы":
                    Inv.SetItem("Черная огненная бомба", 2);
                    Inv.SetItem("Огненная бомба", 2);
                    break;
                case "Небесное благославление":
                    Inv.SetItem("Небесное благословение", 1);
                    break;
                default:
                    break;
            }

            Inv.WeaponChanged += Inv_WeaponChanged;
            Inv.ArmorChanged += Inv_ArmorChanged;
        }

        public HeroBase()
        {
            Inv = new Inventory();
            Health = new Stat();
            Mana = new Stat();
            Energy = new Stat();
            Damage = new Stat();
            Armor = new StatDouble();
            Inv.WeaponChanged += Inv_WeaponChanged;
            Inv.ArmorChanged += Inv_ArmorChanged;
        }

        private void Inv_ArmorChanged()
        {
            armor.Max = armor.Base;
            Armor item = Inv.GetItem(Inv.Armor) as Armor;
            armor.Max = armor.Base + item.Defence;
            armor.Reset();
        }

        private void Inv_WeaponChanged()
        {
            damage.Max = damage.Base;
            Weapon item = Inv.GetItem(Inv.Weapon) as Weapon;
            damage.Max = damage.Base + item.Damage;
            damage.Reset();
        }


        public void CalcStats()
        {
            armor.Max = armor.Base;
            damage.Max = damage.Base;
            UpdateStats();
            FullResetStats();
        }

        private void FullResetStats()
        {
            damage.FullReset();
            armor.FullReset();
            health.FullReset();
            mana.FullReset();
            energy.FullReset();
        }

        public void ReCaclCost()
        {
            Core.Settings.UpgradeCost = Convert.ToInt32(0.0068 * Math.Pow(strength + agility + stamina + intellect, 3) - 0.06 * Math.Pow(strength + agility + stamina + intellect, 2) + 17.1 * (strength + agility + stamina + intellect) + 639);
        }

        private void ResetStats()
        {
            damage.Reset();
            armor.Reset();
            health.Reset();
            mana.Reset();
            energy.Reset();
        }

        public void UpdateStats()
        {
            health.Max =  80 + (stamina * 5);
            mana.Max = 50 + (intellect * 5);
            energy.Max =  50 + agility;
            damage.Max = 5 + (strength / 2);
            armor.Max = 0.05 + (strength * 0.1) / 40;
            ResetStats();
        }

        public bool CheckDie()
        {
            if (Health.Current <= 0)
            {
                Core.Settings.Stats.DeathCount++;
                MessageBox.Show("Вы умерли");
                Core.Settings.PageController.ChangeWindow(Pages.Lotrik);
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
            if (Inv.GetItem(0).Count < estusCount) 
            {
                Inv.AddItem("Эстус", estusCount - Inv.GetItem(0).Count);
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
