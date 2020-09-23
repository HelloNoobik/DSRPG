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

        public BoneFire()
        {
            InitializeComponent();
        }

        public BoneFire(Point point,UI.Lotrik lotrik) :this()
        {
            Width = 40;
            Height = 40;
            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;
            Margin = new Thickness(point.X, point.Y, 0, 0);

            image = new Image();
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/skewer.png",UriKind.Relative));
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Margin = new Thickness(0, 0, 0, 0);
            image.Width = Width;
            image.Height = Height;
            grid.Children.Add(image);


            lotrik.grid.Children.Add(this);
        }
    }
}
