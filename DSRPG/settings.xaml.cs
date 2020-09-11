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

namespace DSRPG
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(Point point)
        {
            InitializeComponent();
            this.ChangeLocation(point);
            VolumeSlider.Value = Settings.Volume;
            VolumeValueLabel.Content = $"{Math.Round(Settings.Volume * 100)} %";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(this.GetLocation());
            mainWindow.Show();
            this.Close();
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Volume = VolumeSlider.Value;
            VolumeValueLabel.Content = $"{Math.Round(Settings.Volume * 100)} %";
        }
    }
}
