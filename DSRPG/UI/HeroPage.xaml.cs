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
using System.Windows.Threading;
using DSRPG.GameLogic.Mechanics;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для HeroPage.xaml
    /// </summary>
    public partial class HeroPage : Page
    {
        private static Inventory inv = new Inventory();
        public HeroPage()
        {
            InitializeComponent();
            LoadInventory();
        }

        private void LoadInventory() 
        {
            Point point = new Point(10, 15);
            for (int i = 0; i < inv.GetCountItems(); i++) 
            {
                Slot slot = new Slot(inv.GetItem(i).Name, new Point(point.X, point.Y), new Size(50, 50), new BitmapImage(new Uri(inv.GetItem(i).Image, UriKind.Relative)), InventoryWindow);
                point.X += slot.Size.Width + 10;

                slot.MouseEnter += Slot_MouseEnter;
                slot.MouseLeave += Slot_MouseLeave;

                if (point.X == 250)
                {
                    if (point.Y == InventoryWindow.Height - 65)
                    {
                        point.Y += 30 + slot.Size.Height;
                        point.X = 10;
                        InventoryWindow.Height += 200;
                    }
                    else 
                    {
                        point.X = 10;
                        point.Y += slot.Size.Height + 10;      
                    }
                }
            }
        }

        private void Slot_MouseEnter(object sender, MouseEventArgs e) 
        {
            Slot slot = (Slot)sender;
            slot.ChangeBorder(Brushes.Yellow);
        }

        private void Slot_MouseLeave(object sender, MouseEventArgs e)
        {
            Slot slot = (Slot)sender;
            slot.ChangeBorder(Brushes.White);
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

        private void Canvas_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
