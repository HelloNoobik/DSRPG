using DSRPG.Classes.Hero;
using DSRPG.Core;
using DSRPG.UI;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading;
namespace DSRPG.Classes.Arena
{
    public class Battle
    {
        public Mobsbase Mob;
        public HeroBase Hero;
        private BattleArena arena;
        public Battle(Mobsbase mob, BattleArena arena)
        {
            this.Mob = mob;
            this.Hero = Settings.Hero;
            this.arena = arena;
            arena.hpbar.DataContext = Hero.Health;
            arena.manabar.DataContext = Hero.Mana;
            arena.energybar.DataContext = Hero.Energy;
            arena.hpbar.Maximum = Hero.Health.Max;
            arena.manabar.Maximum = Hero.Mana.Max;
            arena.energybar.Maximum = Hero.Energy.Max;
            arena.Mobhp.DataContext = Mob;
            arena.Mobmana.DataContext = Mob;
            arena.Mobenergy.DataContext = Mob;
            arena.Mobhp.Maximum = Mob.Health;
            arena.Mobmana.Maximum = Mob.Mana;
            arena.Mobenergy.Maximum = Mob.Energy;

            arena.dmg.Click += Dmg_Click;
            arena.run.Click += Run_Click;
            arena.runthought.Click += Runthought_Click;
            arena.Unloaded += Arena_Unloaded;

        }

        private void Arena_Unloaded(object sender, RoutedEventArgs e)
        {
            Settings.Hero = Hero;
        }

        private void Runthought_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Random rand = new Random();
            int par = Convert.ToInt32(rand.Next(1, 10));
            if(par >= 7)
            {
                MessageBox.Show("Вы пробежали потеряв здоровье");
                Hero.Health.Current -= 20;
                Settings.PositionInCompaign++;
                Settings.PageController.ChangeWindow(Pages.Lotrik);

            }
            else
            {
                MessageBox.Show("Вам не удалось пробежать");
                Hero.Health.Current /= 2;
                Mobdmg();
            }
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Random rand = new Random();
            int par = Convert.ToInt32(rand.Next(1,10));
            if(par >=8)
            {
                MessageBox.Show("Вы сбежали");
                Settings.PageController.ChangeWindow(Pages.Lotrik);
            }
            else
            {
                MessageBox.Show("Вы не сбежали");
                Hero.Health.Current /= 2;
                Mobdmg();
            }
        }

        private void Dmg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
            Mobdmg();
            Herodmg();
        }
    
        public void Herodmg()
        {
            MessageBox.Show("Ваш ход");
            Mobresist();
        }

        public void Mobdmg()
        {
            MessageBox.Show("Ход врага");
            Thread.Sleep(1000);
            CheckResist();
        }

        public void CheckResist()
        {
            Hero.Health.Current -= Convert.ToInt32(Mob.Damage * (1 - Hero.Armor.Current));
        }
        public void Mobresist()
        {
            Mob.Health -= Convert.ToInt32(Hero.Damage.Current * (1 - Mob.Armor));
        }
    }
}
