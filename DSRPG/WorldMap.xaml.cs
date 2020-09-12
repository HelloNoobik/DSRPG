using DSRPG.Classes;
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
using System.Windows.Shapes;

namespace DSRPG
{
    /// <summary>
    /// Логика взаимодействия для WorldMap.xaml
    /// </summary>
    public partial class WorldMap : Window
    {
        static private bool MousePressed = false;
        static private Point MousePrev;
        static private Rect LotrikRect = new Rect(380, 324, 250, 40);
        public WorldMap(Point point)
        {
            this.SetLocation(point);
            InitializeComponent();
        }

        private void MapWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!MousePressed) 
            {
                MousePressed = true;
                MousePrev = e.GetPosition(this);
            }
            if (LotrikRect.Contains(e.GetPosition(MapImage))) 
            {
                FirstLocation window = new FirstLocation(this.GetLocation());
                window.Show();
                this.Close();
            }
        }

        private void MapWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MousePressed = false;
        }

        private void MapWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                Point Mouse = e.GetPosition(null);
                double X =  WorldMapView.HorizontalOffset + (MousePrev.X - Mouse.X);
                double Y = WorldMapView.VerticalOffset + (MousePrev.Y - Mouse.Y);
                WorldMapView.ScrollToVerticalOffset(Y);
                WorldMapView.ScrollToHorizontalOffset(X);
                MousePrev = Mouse;
            }
            if (LotrikRect.Contains(e.GetPosition(MapImage))) 
            {
                Lotrik_button.BorderBrush = Brushes.Yellow;
            }
            else Lotrik_button.BorderBrush = Brushes.White;
        }

        private void MapWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            MousePressed = false;
        }
    }
}
