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
using DSRPG.GameLogic.ViewModel;
using DSRPG.Core;
using DSRPG.Classes.Hero;

namespace DSRPG.UI
{
    public partial class CreateCharacter : Page
    {
        static private CreateCharacterViewModel Model = new CreateCharacterViewModel();
        static private Label activeLabel = null;
        static private Label ActiveLabel
        {
            get
            {
                return activeLabel;
            }

            set
            {
                value.Foreground = Brushes.Yellow;
                if (activeLabel != null) activeLabel.Foreground = Brushes.White;
                activeLabel = value;
            }
        }
        public CreateCharacter()
        {
            InitializeComponent();
            DataContext = Model;
        }

        private void NameLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
            Model.ChangePage("Name");
        }

        private void GenderLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
            Model.ChangePage("Gender");
        }

        private void ClassLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
            Model.ChangePage("Class");
        }

        private void GiftLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
            Model.ChangePage("Gift");
        }

        private void MouseEnter(object sender, MouseEventArgs e)
        {
            if ((Label)sender != ActiveLabel)
            {

                Label label = (Label)sender;
                label.Foreground = Brushes.Yellow;
            }
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            if ((Label)sender != ActiveLabel)
            {

                Label label = (Label)sender;
                label.Foreground = Brushes.White;
            }
        }

        private void Submit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            HeroBase Hero = Model.Check();
            if (Hero != null)
            {
                Settings.Hero = Hero;
                Settings.MediaController.MainMenuMusicPlaying = false;
                Settings.MediaController.StopMusic();
                Settings.PageController.ChangeWindow(Pages.Intro);
            }
            else MessageBox.Show("Не все заполнено");
        }

        private void Cancel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            Settings.PageController.ChangeWindow(Pages.Main);
        }
    }
}
