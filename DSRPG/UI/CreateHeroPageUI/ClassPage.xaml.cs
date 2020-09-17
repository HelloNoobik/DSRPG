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

namespace DSRPG.UI.CreateHeroPageUI
{
    /// <summary>
    /// Логика взаимодействия для ClassPage.xaml
    /// </summary>
    public partial class ClassPage : Page
    {
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
        public ClassPage()
        {
            InitializeComponent();
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

        private void Warrior_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
        }

        private void Paladin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
        }

        private void Archer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
        }

        private void Mage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            ActiveLabel = (Label)sender;
        }

        public string GetResult() 
        {
            if (ActiveLabel == null) return "";
            return ActiveLabel.Content.ToString();
        }
    }
}
