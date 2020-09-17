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
using DSRPG.GameLogic.Core;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для WorldMap.xaml
    /// </summary>
    public partial class WorldMap : Page
    {
        static private bool MousePressed = false;
        static private Point MousePrev;
        static private Rect LotrikRect = new Rect(380, 324, 250, 40);
        public WorldMap()
        {
            InitializeComponent();
        }

        private void MapPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!MousePressed)
            {
                MousePressed = true;
                MousePrev = e.GetPosition(this);
            }
            if (LotrikRect.Contains(e.GetPosition(MapImage)))
            {
                Settings.MediaController.StopMusic();
                Settings.PageController.ChangeWindow(Pages.Lotrik);
            }
        }

        private void MapPage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MousePressed = false;
        }

        private void MapPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                Point Mouse = e.GetPosition(null);
                double X = WorldMapView.HorizontalOffset + (MousePrev.X - Mouse.X);
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

        private void MapPage_MouseLeave(object sender, MouseEventArgs e)
        {
            MousePressed = false;
        }

        private void back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Settings.PageController.ChangeWindow(Pages.Main);
        }


        private void MapPage_Unloaded(object sender, RoutedEventArgs e)
        {
            Settings.MediaController.WorldMusicPlaying = false;
            Settings.MediaController.StopMusic();
        }

        private void MapPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Settings.MediaController.WorldMusicPlaying)
            {
                Settings.MediaController.WorldMusicPlaying = true;
                Settings.MediaController.PlayMusic(DSRPG.Resources.Links.Music.World);
            }
        }
    }
}
