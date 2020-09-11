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

namespace DSRPG
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var player = new MediaPlayer();
            player.MediaFailed += (s, e) => MessageBox.Show("Error");
            player.Open(new Uri("music/Shirrako - Dark Souls III Soundtrack OST - Main Menu Theme_(Inkompmusic.ru).mp3", UriKind.Relative));
            player.Play();
        }

        private void ExitButt_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void NewGameButt_Click(object sender, RoutedEventArgs e)
        {
            CreateCharacter createcharacter = new CreateCharacter();
            createcharacter.Show();
            this.Close();
        }

        private void SettingsButt_Click(object sender, RoutedEventArgs e)
        {
            Window1 settings = new Window1();
            settings.Show();
            this.Close();
        }
    }
}
