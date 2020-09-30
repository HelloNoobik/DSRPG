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

namespace DSRPG.Classes.Company
{
    /// <summary>
    /// Логика взаимодействия для BoneFire.xaml
    /// </summary>
    public partial class BoneFire : UserControl
    {
        private Image image;
        private bool active = true;
        public BoneFire()
        {
            InitializeComponent();
        }

        public BoneFire(UI.Lotrik lotrik) :this()
        {
            Width = 200;
            Height = 200;
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            Margin = new Thickness(600, 0, 0, 0);

            image = new Image();
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/bonefire.png",UriKind.Relative));
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Margin = new Thickness(0, 0, 0, 0);
            image.Width = Width;
            image.Height = Height;
            grid.Children.Add(image);

            lotrik.grid.Children.Add(this);

            Core.Settings.PositionChanged += Settings_PositionChanged;
            MouseLeftButtonDown += BoneFire_MouseLeftButtonDown;
        }

        private void BoneFire_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Core.Settings.PageController.ChangeWindow(Pages.BoneFire);
        }

        private void Settings_PositionChanged()
        {
            int pos = Core.Settings.PositionInCompaign;
            if (pos == 0 || pos  == 3 || pos == 6)
            {
                Opacity = 1.0;
                Visibility = Visibility.Visible;
            }
            else 
            {
                Opacity = 0.5;
                Visibility = Visibility.Hidden;
            }
        }
    }
}
