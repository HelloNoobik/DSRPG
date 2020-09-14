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
using DSRPG.Core;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            if (!Settings.Media.MainMenuMusicPlaying)
            {
                Settings.Media.MainMenuMusicPlaying = true;
                Settings.Media.PlayMusic("music/MainTheme.mp3");
            }
        }

        private void MouseEnter(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.Foreground = Brushes.Yellow;
            
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            label.Foreground = Brushes.White;
        }

        private void NewGameLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
            Settings.Main.ChangeWindow(Pages.CreateCharacter);
        }

        private void LoadGameLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
        }

        private void SettingsLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
            Settings.Main.ChangeWindow(Pages.Settings);
        }

        private void ExitLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
            Environment.Exit(0);
        }
    }
}
