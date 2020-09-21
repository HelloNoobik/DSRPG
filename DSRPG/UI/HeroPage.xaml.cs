using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using DSRPG.Classes;
using DSRPG.Classes.Hero;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для HeroPage.xaml
    /// </summary>
    public partial class HeroPage : Page
    {
        public HeroPage()
        {
            InitializeComponent();
        }

        private void LoadInventory()
        {
            Inventory inv = Core.Settings.Hero.inv;
            Point point = new Point(10, 15);
            for (int i = 0; i < inv.GetCountItems(); i++)
            {
                if (inv.GetItem(i).Count <= 0) continue;
                Slot slot = new Slot(i, this);
                slot.Location = point;

                point.X += slot.Width + 10;

                if (point.X == 250)
                {
                    if (point.Y == InventoryWindow.Height - 65)
                    {
                        point.Y += 30 + slot.Height;
                        point.X = 10;
                        InventoryWindow.Height += 200;
                    }
                    else
                    {
                        point.X = 10;
                        point.Y += slot.Height + 10;
                    }
                }
            }
            Core.Settings.Hero.inv = inv; 
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            double Y = ScrollInv.VerticalOffset + 200;
            ScrollInv.ScrollToVerticalOffset(Y);
        }
        private void prev_Click(object sender, RoutedEventArgs e)
        {
            double Y = ScrollInv.VerticalOffset - 200;
            ScrollInv.ScrollToVerticalOffset(Y);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.Settings.HeroPageIsOpened = false;
            Core.Settings.Lotrik.ChangePage("Hide");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Hp.DataContext = Core.Settings.Hero.Health;
            Mana.DataContext = Core.Settings.Hero.Mana;
            Energy.DataContext = Core.Settings.Hero.Energy;
            damage.DataContext = Core.Settings.Hero.Damage;
            armor.DataContext = Core.Settings.Hero.Armor;
            LoadInventory();
            DataContext = Core.Settings.Hero;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string result = "";
            foreach (int index in Core.Settings.Hero.inv.GetSlots()) 
            {
                if (index == -1) 
                { 
                    result += $"{index} - Слот пуст {Environment.NewLine}";
                    continue;
                }
                Item item = Core.Settings.Hero.inv.GetItem(index);
                result += $"{index} - {item.Name} - {item.Count}{Environment.NewLine}";
            }
            MessageBox.Show(result);
        }
    }
}
