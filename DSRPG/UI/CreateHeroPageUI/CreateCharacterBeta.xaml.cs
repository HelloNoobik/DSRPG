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
    /// Логика взаимодействия для CreateCharacterBeta.xaml
    /// </summary>
    public partial class CreateCharacterBeta : Page
    {
        static private ViewModel.CreateCharacterViewModel Model = new ViewModel.CreateCharacterViewModel();
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
                if(activeLabel != null)activeLabel.Foreground = Brushes.White;
                activeLabel = value;
            }
        }
        public CreateCharacterBeta()
        {
            InitializeComponent();
            DataContext = Model;
        }

        private void NameLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
            ActiveLabel = (Label)sender;
            Model.ChangePage("Name");
        }

        private void GenderLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
            ActiveLabel = (Label)sender;
            Model.ChangePage("Gender");
        }

        private void ClassLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
            ActiveLabel = (Label)sender;
            Model.ChangePage("Class");
        }

        private void GiftLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
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
            Settings.Media.PlaySound("sound/click.mp3");
            if (Model.Check() != null)
            {
                Core.Settings.Media.MainMenuMusicPlaying = false;
                Core.Settings.Media.StopMusic();
                Core.Settings.Main.ChangeWindow(Pages.Intro);
            }
            else MessageBox.Show("Не все заполнено");
        }

        private void Cancel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Settings.Media.PlaySound("sound/click.mp3");
            Core.Settings.Main.ChangeWindow(Pages.Main);
        }
    }
}
