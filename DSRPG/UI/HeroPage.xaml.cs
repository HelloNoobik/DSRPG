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

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для HeroPage.xaml
    /// </summary>
    public partial class HeroPage : Page
    {
        private static DSRPG.GameLogic.Mechanics.Inventory inv = new DSRPG.GameLogic.Mechanics.Inventory();
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
                Rectangle rect = new Rectangle();
                Canvas.SetLeft(rect, point.X);
                Canvas.SetTop(rect, point.Y);
                rect.Name = $"SlotRect{i}";
                rect.Height = 50;
                rect.Width = 50;
                rect.Stroke = Brushes.White;
                InventoryWindow.Children.Add(rect);
                Image img = new Image();
                Canvas.SetLeft(img, point.X);
                Canvas.SetTop(img, point.Y);
                img.Name = $"SlotImg{i}";
                img.Height = 50;
                img.Width = 50;
                img.Source = new BitmapImage(new Uri(inv.GetItem(i).Image,UriKind.Relative));
                InventoryWindow.Children.Add(img);
                point.X += rect.Width + 10;

                rect.MouseEnter += Slot_MouseEnter;
                rect.MouseLeave += Slot_MouseLeave;

                //img.MouseEnter += Slot_MouseEnter;
                //img.MouseLeave += Slot_MouseLeave;
                

                if (point.X == 250)
                {
                    if (point.Y == InventoryWindow.Height - 65)
                    {
                        point.Y += 30 + rect.Height;
                        point.X = 10;
                        InventoryWindow.Height += 200;
                    }
                    else 
                    {
                        point.X = 10;
                        point.Y += rect.Height + 10;      
                    }
                }
            }
        }

        private void Slot_MouseEnter(object sender, MouseEventArgs e) 
        {
            Rectangle image = (Rectangle)sender;
            image.Stroke = Brushes.Yellow;
        }

        private void Slot_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle image = (Rectangle)sender;
            image.Stroke = Brushes.White;
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
    }
}
