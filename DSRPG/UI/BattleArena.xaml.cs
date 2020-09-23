
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DSRPG.Classes.Hero;
using DSRPG.Core;
using DSRPG.Test;
using DSRPG.Classes;
using DSRPG.Classes.Mobs;
using DSRPG.Classes.Arena;
using System.Windows.Media.Animation;
using System.Configuration;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для BattleArena.xaml
    /// </summary>
    public partial class BattleArena : Page
    {
        static private Battle battle;
        public BattleArena()
        {
            InitializeComponent();
            battle = new Battle(new Thief(this), this);
            
            
        }

        private void ProgressBar_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Room_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void hp_Click(object sender, RoutedEventArgs e)
        {
            battle.Hero.Health.Current--;
            battle.Hero.Mana.Current--;
            battle.Hero.Energy.Current--;
            battle.Mob.Health--;
            battle.Mob.Mana--;
            battle.Mob.Energy--;
        }

        private void slot_click(object sender,MouseButtonEventArgs e)
        {
            Random rand = new Random();
            Item item = (sender as Slot).GetItem();
            if (item == null) return;
            if (item.Count == 0) return;
            switch (item.Name)
            {
                case "Эстус":
                    battle.Hero.Health.Current += 30;
                    Core.Settings.Hero.Inv.RemoveItem(item.Name,1);
                    break;
                case "Человечность":
                    battle.Hero.Health.Reset();
                    Core.Settings.Hero.Inv.RemoveItem(item.Name,1);
                    break;
                case "Небесное благословение":
                    battle.Hero.Health.Current += 50;
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                case "Черная огненная бомба":
                    battle.Mob.Health -= rand.Next(40,60);
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                case "Огненная бомба":
                    battle.Mob.Health -= rand.Next(20,30);
                    Core.Settings.Hero.Inv.RemoveItem(item.Name, 1);
                    break;
                default:
                    break;

            }
            Update();

            
        }
        private void BattleArena_load(object sender,RoutedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            if (Core.Settings.Hero.Inv.Slot1 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot1);
                Slot0.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot2 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot2);
                Slot1.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot3 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot3);
                Slot2.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot4 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot4);
                Slot3.SetSlot(item);
            }
            if (Core.Settings.Hero.Inv.Slot5 != -1)
            {
                Item item = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Slot5);
                Slot4.SetSlot(item);
            }
        }
    }
}
