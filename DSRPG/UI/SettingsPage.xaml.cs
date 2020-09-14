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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            MasterVolumeSlider.Value = Settings.MasterVolume;
            MasterVolumeLabel.Content = $"{Math.Round(Settings.MasterVolume * 100)} %";
            MusicVolumeSlider.Value = Settings.MusicVolume;
            MusicVolumeLabel.Content = $"{Math.Round(Settings.MusicVolume * 100)} %";
            SoundVolumeSlider.Value = Settings.SoundVolume;
            SoundVolumeLabel.Content = $"{Math.Round(Settings.SoundVolume * 100)} %";
            VideoVolumeSlider.Value = Settings.VideoVolume;
            VideoVolumeLabel.Content = $"{Math.Round(Settings.VideoVolume * 100)} %";
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

        private void VideoVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.VideoVolume = VideoVolumeSlider.Value;
            VideoVolumeLabel.Content = $"{Math.Round(Settings.VideoVolume * 100)} %";
        }

        private void BackLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            BackLabel.Foreground = Brushes.Yellow;
        }

        private void BackLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            BackLabel.Foreground = Brushes.White;
        }

        private void BackLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             Settings.MediaController.PlaySound(DSRPG.Resources.Links.Sound.Click);
            Settings.PageController.ChangeWindow(Pages.Main);
        }
    }
}
