using DSRPG.Classes.Hero;
using DSRPG.Data;
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

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для SaveLoad.xaml
    /// </summary>
    public partial class SaveLoad : Page
    {
        public SaveLoad()
        {
            InitializeComponent();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Players player = null;
            string _class = "";
            List<ItemList> items = new List<ItemList>();
            using (DSRPGEntities db = new DSRPGEntities()) 
            {
                if (db.Players.Where(c => c.Name == Name.Text).Count() == 0)
                {
                    MessageBox.Show("Персонаж не найден");
                    return;
                }

                player = db.Players.Where(c => c.Name == Name.Text).First();
                items = db.ItemList.Where(c => c.PlayerName == player.Name).ToList();
                _class = db.Classes.Where(c => c.Id == player.ClassId).First().Class;
            }

            switch (_class)
            {
                case "Воин":
                    Core.Settings.Hero = new Warrior();
                    break;
                case "Паладин":
                    Core.Settings.Hero = new Paladin();
                    break;
                case "Лучник":
                    Core.Settings.Hero = new Archer();
                    break;
                case "Маг":
                    Core.Settings.Hero = new Mage();
                    break;
                default:
                    break;

            }

            Core.Settings.Hero.Name = player.Name;
            Core.Settings.Hero.Souls = player.Souls;
            Core.Settings.Hero.Stamina = player.Stamina;
            Core.Settings.Hero.Strength = player.Strength;
            Core.Settings.Hero.Agility = player.Agility;
            Core.Settings.Hero.Intellect = player.Intellect;
            Core.Settings.Hero.EstusCount = player.EstusCount;
            Core.Settings.Hero.CalcStats();

            Core.Settings.TradeCost = player.TraderCost;
            Core.Settings.PositionInCompaign = player.Position;


            foreach(ItemList item in items) 
            {
                Core.Settings.Hero.Inv.AddItem(item.ItemName, item.Count);
            }

            Core.Settings.PageController.ChangeWindow(Pages.WorldMap);
        }
    }
}
