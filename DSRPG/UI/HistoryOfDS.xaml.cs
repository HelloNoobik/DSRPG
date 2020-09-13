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
using System.Windows.Threading;
using static Core.Core;
using Core;

namespace DSRPG
{
    /// <summary>
    /// Логика взаимодействия для HistoryOfDS.xaml
    /// </summary>
    public partial class HistoryOfDS : Window
    {
        public HistoryOfDS(Point point)
        {
            InitializeComponent();
            this.SetLocation(point);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorldMap worldMap = new WorldMap(this.GetLocation());
            this.Close();
            worldMap.Show();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") 
            {
                Player.Stop();
                WorldMap worldMap = new WorldMap(this.GetLocation());
                worldMap.Show();
                this.Close();
            }
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += (s, ee) => 
            { 
                Player.Opacity += 0.001;
                if (Player.Opacity == 1.0) timer.Stop();
            };
            Player.Opacity = 0.0;
            timer.Start();
            Player.Source = new Uri("video/DS_opening.mp4", UriKind.Relative);
            Player.Volume = Settings.VideoVolume;
            Player.Stretch = Stretch.Fill;
            Player.LoadedBehavior = MediaState.Manual;
            Player.UnloadedBehavior = MediaState.Manual;
            Player.Play();
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            WorldMap worldMap = new WorldMap(this.GetLocation());
            worldMap.Show();
            this.Close();
        }
    }
}
