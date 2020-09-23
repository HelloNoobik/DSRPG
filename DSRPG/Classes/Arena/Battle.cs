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

            arena.Loaded += Arena_Loaded;
            arena.dmg.Click += Dmg_Click;
            arena.run.Click += Run_Click;
            arena.runthought.Click += Runthought_Click;
            arena.Unloaded += Arena_Unloaded;

            arena.Slot0.MouseLeftButtonDown += slot_click;
            arena.Slot1.MouseLeftButtonDown += slot_click;
            arena.Slot2.MouseLeftButtonDown += slot_click;
            arena.Slot3.MouseLeftButtonDown += slot_click;
            arena.Slot4.MouseLeftButtonDown += slot_click;
        }
        private void Arena_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSlots();
        }

        private void LoadSlots()
        {
            if (Core.Settings.Hero.Inv.Slot1 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot1);
                arena.Slot0.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot2 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot2);
                arena.Slot1.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot3 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot3);
                arena.Slot2.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot4 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot4);
                arena.Slot3.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot5 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot5);
                arena.Slot4.SetSlot(item);
            }
        }

        private void slot_click(object sender, MouseButtonEventArgs e)
        {
            Random rand = new Random();
            Slot slot = sender as Slot;
            Item item = slot.GetItem();
            if (item == null) return;
            if (item.Count == 0) return;
            switch (item.Name)
            {
                case "Эстус":
                    Hero.Health.Current += 30;
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                case "Человечность":
                    Hero.Health.Reset();
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                case "Небесное благословение":
                    Hero.Health.Current += 50;
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                case "Черная огненная бомба":
                    Mob.Health -= rand.Next(40, 60);
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                case "Огненная бомба":
                    Mob.Health -= rand.Next(20, 30);
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                default:
                    break;

            }
            LoadSlots();
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
        private void Herodmg()
        {
            MessageBox.Show("Ваш ход");
            Mobresist();
        }
        private void Mobdmg()
        {
            MessageBox.Show("Ход врага");
            Thread.Sleep(1000);
            CheckResist();
        }
        private void CheckResist()
        {
            Hero.Health.Current -= Convert.ToInt32(Mob.Damage * (1 - Hero.Armor.Current));
        }
        private void Mobresist()
        {
            Mob.Health -= Convert.ToInt32(Hero.Damage.Current * (1 - Mob.Armor));
        }
    }
}
