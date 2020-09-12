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
using Core;

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
            this.SetLocation(point);
            MasterVolumeSlider.Value = Settings.MasterVolume;
            MasterVolumeLabel.Content = $"{Math.Round(Settings.MasterVolume * 100)} %";
            MusicVolumeSlider.Value = Settings.MusicVolume;
            MusicVolumeLabel.Content = $"{Math.Round(Settings.MusicVolume * 100)} %";
            SoundVolumeSlider.Value = Settings.SoundVolume;
            SoundVolumeLabel.Content = $"{Math.Round(Settings.SoundVolume * 100)} %";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(this.GetLocation());
            mainWindow.Show();
            this.Close();
        }

        private void MasterVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.MasterVolume = MasterVolumeSlider.Value;
            MasterVolumeLabel.Content = $"{Math.Round(Settings.MasterVolume * 100)} %";
        }

        private void MusicVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.MusicVolume = MusicVolumeSlider.Value;
            MusicVolumeLabel.Content = $"{Math.Round(Settings.MusicVolume * 100)} %";
        }

        private void SoundVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.SoundVolume = SoundVolumeSlider.Value;
            SoundVolumeLabel.Content = $"{Math.Round(Settings.SoundVolume * 100)} %";
        }
    }
}
