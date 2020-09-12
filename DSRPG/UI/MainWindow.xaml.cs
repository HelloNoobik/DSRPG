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
using static Core.Core;

namespace DSRPG
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!Media.MainMenuMusicPlaying) 
            {
                Media.MainMenuMusicPlaying = true;
                Media.SetMusic(new Uri("music/MainTheme.mp3", UriKind.Relative));
                Media.PlayMusic();
            }
        }
        public MainWindow(Point point)
        {
            InitializeComponent();
            this.SetLocation(point);
            if (!Media.MainMenuMusicPlaying)
            {
                Media.MainMenuMusicPlaying = true;
                Media.SetMusic(new Uri("music/MainTheme.mp3", UriKind.Relative));
                Media.PlayMusic();
            }
        }

        private void NewGame_MouseEnter(object sender, MouseEventArgs e)
        {
            NewGameLb.Foreground = Brushes.Yellow;
        }

        private void NewGame_MouseLeave(object sender, MouseEventArgs e)
        {
            NewGameLb.Foreground = Brushes.White;
        }

        private void LoadGame_MouseEnter(object sender, MouseEventArgs e)
        {
            LoadGameLb.Foreground = Brushes.Yellow;
        }

        private void LoadGame_MouseLeave(object sender, MouseEventArgs e)
        {
            LoadGameLb.Foreground = Brushes.White;
        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            SettingsLb.Foreground = Brushes.Yellow;
        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
            SettingsLb.Foreground = Brushes.White;
        }

        private void Exit_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitLb.Foreground = Brushes.Yellow;
        }

        private void Exit_MouseLeave(object sender, MouseEventArgs e)
        {
           ExitLb.Foreground = Brushes.White;
        }

        private void NewGameLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CreateCharacter createcharacter = new CreateCharacter(this.GetLocation());
            createcharacter.Show();
            this.Close();
        }

        private void LoadGameLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void SettingsLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window1 settings = new Window1(this.GetLocation());
            settings.Show();
            this.Close();
        }

        private void ExitLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
