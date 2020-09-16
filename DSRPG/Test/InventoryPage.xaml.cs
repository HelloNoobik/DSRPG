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
using DSRPG.GameLogic.Hero;
namespace DSRPG.Test
{
    /// <summary>
    /// Логика взаимодействия для InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        static private Inventory inve = new Inventory();
        public InventoryPage()
        {
            InitializeComponent();

            Point point = new Point(25,25);
            for(int i = 0; i < inve.GetCountItems(); i++)
            {
                /*Item item = inve.GetItem(i);
                Rectangle rect = new Rectangle();
                rect.Name = item.Name;
                rect.PreviewMouseLeftButtonDown += Click;
                rect.MouseEnter += MouseEnter;
                rect.MouseLeave += MouseLeave;
                rect.Width = 50;
                rect.Height = 50;
                rect.Stroke = Brushes.White;
                rect.Fill = Brushes.White;
                Canvas.SetLeft(rect, point.X);
                Canvas.SetTop(rect, point.Y);
               // Window.Children.Add(rect);
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(item.Image, UriKind.Relative));
                image.Width = 50;
                image.Height = 50;
                Canvas.SetLeft(image, point.X);
                Canvas.SetTop(image, point.Y);
               // Window.Children.Add(image);
                point.X += 75;
                if(point.X >= 725)
                {
                    point.X = 25;
                    point.Y += 75;
                }*/
            }
        }
        private void Click(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            MessageBox.Show($"{rect.Name}");
        }
        private void MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            rect.Stroke = Brushes.Red;
        }
        private void MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            rect.Stroke = Brushes.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Archer archer = new Archer();
            if (archer.CheckDie()) MessageBox.Show("C");
            if (archer.CheckNoneMana()) MessageBox.Show("0");
        }
    }
}
