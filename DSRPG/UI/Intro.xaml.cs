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
using DSRPG.GameLogic.Core;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для Intro.xaml
    /// </summary>
    public partial class Intro : Page
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
            {
                Player.Close();
                Settings.PageController.ChangeWindow(Pages.WorldMap);
                Window.GetWindow(this).KeyDown -= Page_KeyDown;
            }
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Player.Close();
            Settings.PageController.ChangeWindow(Pages.WorldMap);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Player.Source = DSRPG.Resources.Links.Video.Intro;
            Player.Volume = Settings.VideoVolume;
            Player.Stretch = Stretch.Fill;
            Player.LoadedBehavior = MediaState.Manual;
            Player.UnloadedBehavior = MediaState.Manual;
            Player.Play();
            Window.GetWindow(this).KeyDown += Page_KeyDown;
            Animation();
        }

        private async void Animation() 
        {
            await Task.Factory.StartNew(() => 
            {
                Thread.Sleep(3000);
                for (double i = 1.0; i > 0.0;i-= 0.01) 
                {
                    Dispatcher.Invoke(() => { Skip.Opacity = i; });
                    Thread.Sleep(50);
                }
            });
        }
    }
}
