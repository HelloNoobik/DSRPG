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

namespace DSRPG
{
    /// <summary>
    /// Логика взаимодействия для HistoryOfDS.xaml
    /// </summary>
    public partial class HistoryOfDS : Window
    {
        DispatcherTimer timer;
        public HistoryOfDS(Point point)
        {
            InitializeComponent();
            this.SetLocation(point);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender,EventArgs e)
        {
            slider1.Value = media.Position.TotalSeconds;
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
                //Пропуск кат сцены
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
           media.Stop();
        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = media.NaturalDuration.TimeSpan;
            slider1.Maximum = ts.TotalSeconds;
            timer.Start();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Position = TimeSpan.FromSeconds(slider1.Value);
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media.Volume = (double)slider2.Value;
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            var frpg_opening = @"https://www.youtube.com/embed/ylFzJ3wRgHw";
            media.Source = new Uri(frpg_opening,UriKind.Absolute);
            media.MediaFailed += (s, ee) => { MessageBox.Show(ee.ErrorException.ToString()); };
            media.LoadedBehavior = MediaState.Manual;
            media.UnloadedBehavior = MediaState.Manual;
            media.Volume = (double)slider2.Value;
            media.Play();
            
        }
    }
}
