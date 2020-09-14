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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            if (!Settings.MediaController.MainMenuMusicPlaying)
            {
                Settings.MediaController.MainMenuMusicPlaying = true;
                Settings.MediaController.PlayMusic(DSRPG.Resources.Links.Music.Main);
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
            Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);

            Settings.PageController.ChangeWindow(Pages.CreateCharacter);
        }

        private void LoadGameLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
        }

        private void SettingsLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            Settings.PageController.ChangeWindow(Pages.Settings);
        }

        private void ExitLb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            Environment.Exit(0);
        }
    }
}
