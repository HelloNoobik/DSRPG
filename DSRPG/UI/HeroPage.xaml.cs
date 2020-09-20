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
            //LoadInventory();
        }

        //private void LoadInventory()
        //{
        //    Point point = new Point(10, 15);
        //    for (int i = 0; i < inv.GetCountItems(); i++)
        //    {
        //        Slot slot = new Slot(inv.GetItem(i), this);
        //        slot.Location = point;

        //        point.X += slot.Width + 10;

        //        if (point.X == 250)
        //        {
        //            if (point.Y == InventoryWindow.Height - 65)
        //            {
        //                point.Y += 30 + slot.Height;
        //                point.X = 10;
        //                InventoryWindow.Height += 200;
        //            }
        //            else
        //            {
        //                point.X = 10;
        //                point.Y += slot.Height + 10;
        //            }
        //        }
        //    }
        //}

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
            Core.Settings.Lotrik.ChangePage("Hide");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Core.Settings.Hero;
        }
    }
}
