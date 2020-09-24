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
using DSRPG.Classes.Mobs;
using System.Runtime.Remoting.Channels;

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
            arena.superdmg.Click += Superdmg_Click;
            arena.def.Click += Def_Click;


            arena.Slot0.MouseLeftButtonDown += slot_click;
            arena.Slot1.MouseLeftButtonDown += slot_click;
            arena.Slot2.MouseLeftButtonDown += slot_click;
            arena.Slot3.MouseLeftButtonDown += slot_click;
            arena.Slot4.MouseLeftButtonDown += slot_click;
        }

        private void Def_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Superdmg_Click(object sender, EventArgs e)
        {
            if(Hero.Energy.Current == 50)
            {
                (sender as Button).IsEnabled = true;
                int damage = Hero.Damage.Current + 40;
                Mob.Health -= damage;
                arena.Log.Text += $"Супер удар нанёс урона {damage}\n";
            }
            Hero.Energy.Current = 0;
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
            if(item.Type == ItemType.Spell)
            {
                if (Hero.Mana.Current < (item as Spell).Cost) return;
                Mob.Health -= (item as Spell).Cost;
                Hero.Mana.Current -= (item as Spell).Cost;
            }
            else
            {
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
            if (par >= 7)
            {
                MessageBox.Show("Вы пробежали потеряв здоровье");
                Hero.Health.Current -= 20;
                Settings.PositionInCompaign++;
                Settings.PageController.ChangeWindow(Pages.Lotrik);

            }
            else
            {
                int damage = Hero.Health.Current / 2;
                Hero.Health.Current -= damage;
                arena.Log.Text += $"Вы не пробежали и в ответ получили {damage} урона\n";
                Mobdmg();
            }
        }
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Random rand = new Random();
            int par = Convert.ToInt32(rand.Next(1, 10));
            if (par >= 8)
            {
                MessageBox.Show("Вы сбежали");
                Settings.PageController.ChangeWindow(Pages.Lotrik);
            }
            else
            {
                int damage = Hero.Health.Current / 2;
                Hero.Health.Current -= damage;
                arena.Log.Text += $"Вы не сбежали и получили в спину {damage} урона\n";
                Mobdmg();
            }
        }
        private void Dmg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Hero.Energy.Current += 10;
            Mobdmg();
            Herodmg();
        }
        private void Herodmg()
        {
            arena.Log.Text += $"\nВаш ход,\n\n";
            Mobresist();
        }
        private void Mobdmg()
        {
            arena.Log.Text += $"\nХод врага,\n\n";
            Thread.Sleep(1000);
            CheckResist();
        }
        private void CheckResist()
        {
            int damage = Convert.ToInt32(Mob.Damage * (1 - Hero.Armor.Current));
            arena.Log.Text += Mob.UpMob();
            Hero.Health.Current -= damage;
            arena.Log.Text += $"Противник нанёс {damage} урона\n";
        }
        private void Mobresist()
        {
            int damage = Convert.ToInt32(Hero.Damage.Current * (1 - Mob.Armor));
            Mob.Health -= damage;
            if (Hero.CheckDie()) ;
            else
            {
                Mob.CheckDieMob();
            }
            arena.Log.Text += $"Вы нанесли {damage} урона\n";
        }
    }
}
