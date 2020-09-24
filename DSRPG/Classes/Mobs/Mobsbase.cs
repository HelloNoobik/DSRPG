using DSRPG.Classes.Hero;
using DSRPG.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static DSRPG.Test.Level;

namespace DSRPG.Classes
{
    public  class Mobsbase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        // public event Event Dead;
        protected string name;
        protected int health;
        protected int mana;
        protected int energy;
        protected int damage;
        protected double armor;
        protected Image image;
        protected BattleArena page;
        protected int cost;






        public int Cost
        {
            get { return cost; }
            set { cost = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }
        public int Health
        {
            get { return health; }
            set 
            {
              
                if(health > value)
                {
                    int damage = health - value;
                    Core.Settings.Stats.DamageGiven += damage;
                }
                health = value;
                OnPropertyChanged();
                
            }

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
        public int Damage
        {
            get { return damage; }
            set { damage = value; OnPropertyChanged(); }
        }
        public double Armor
        {
            get { return armor; }
            set { armor = value; OnPropertyChanged(); }
        }

        public Mobsbase(BattleArena arena)
        {
            page = arena;
            image = new Image();
            image.Width = 200;
            image.Height = 200;
        }

        public virtual bool CheckDieMob()
        {
            if (Health <= 0)
            {
                Core.Settings.Hero.Souls += Cost;
                Core.Settings.Stats.Kills++;
                Core.Settings.PositionInCompaign++;
                Core.Settings.PageController.ChangeWindow(Pages.Lotrik);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual string UpMob()
        {
            return "";
        }
        public override string ToString() //Мож пойже пригодится s
        {
            return base.ToString();
        }
    }
}
