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

        public Battle(Mobsbase mob,BattleArena arena)
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

            Hero.Health.Decrease += Health_Decrease;
        }

        private void Health_Decrease(int damage)
        {
            Core.Settings.Stats.DamageTaken += damage;
        }

        private void Def_Click(object sender, RoutedEventArgs e)
        {
            arena.Log.Clear();
            arena.Log.Text += $"Вы можете повысить защиту только до 40%\n";

            if (Hero.Energy.Current >= 10)
            {
                Hero.Armor.Current += 0.1;
                Hero.Energy.Current -= 10;
                Mobdmg();
                if (Hero.Armor.Current >= 0.5)
                {
                    Hero.Armor.Current = Hero.Armor.Base;
                    arena.Log.Text += $"Защита достигла предела(сброс брони до базовой)\n";
                }
            }
        }

        private void Superdmg_Click(object sender, EventArgs e)
        {
            arena.Log.Clear();
            if (Hero.Energy.Current >= 50)
            {
                int damage = Hero.Damage.Current + 40;
                Mob.Health -= damage;
                Hero.Energy.Current -= 50;
                Mobdmg();
                arena.Log.Text += $"Супер удар нанёс урона {damage}\n";
            }
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
                        Hero.Health.Current += 70;
                        Hero.Mana.Current += 40;
                        Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                        break;
                    case "Человечность":
                        Hero.Health.Reset();
                        Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                        break;
                    case "Небесное благословение":
                        Hero.Health.Current += 100;
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
            Mobdmg();
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
                arena.Log.Clear();
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
                arena.Log.Clear();
                int damage = Hero.Health.Current / 2;
                Hero.Health.Current -= damage;
                arena.Log.Text += $"Вы не сбежали и получили в спину {damage} урона\n";
                Mobdmg();
            }
        }
        private void Dmg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            arena.Log.Clear();
            Hero.Armor.Current = Hero.Armor.Base;
            Herodmg();
            Hero.Energy.Current += 10;
            Mobdmg();
        }
        private void Herodmg()
        {
            arena.Log.Text += $"Ваш ход:\n";
            Mobresist();
        }
        private void Mobdmg()
        {
            
            arena.Log.Text += $"Ход врага:\n";
            Thread.Sleep(1000);
            CheckResist();
        }
        private void CheckResist()
        {
            if (Mob.CheckDieMob()) return;
            arena.Log.Text += Mob.UpMob();
            int damage = Convert.ToInt32(Mob.Damage * (1 - Hero.Armor.Current));
            Hero.Health.Current -= damage;
            arena.Log.Text += $"Противник нанёс {damage} урона\n";
        }
        private void Mobresist()
        {
            if (Hero.CheckDie()) return;
            int damage = Convert.ToInt32(Hero.Damage.Current * (1 - Mob.Armor));
            Mob.Health -= damage;
            arena.Log.Text += $"Вы нанесли {damage} урона\n";
        }
    }
}
