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
using System.Windows.Threading;
using static Core.Core;

namespace DSRPG
{
    /// <summary>
    /// Логика взаимодействия для HistoryOfDS.xaml
    /// </summary>
    public partial class HistoryOfDS : Window
    {
        public HistoryOfDS(Point point)
        {
            InitializeComponent();
            this.SetLocation(point);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorldMap worldMap = new WorldMap(this.GetLocation());
            this.Close();
            worldMap.Show();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return") 
            {
                WorldMap worldMap = new WorldMap(this.GetLocation());
                worldMap.Show();
                this.Close();
            }
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            VideoDrawing aVideoDrawing = new VideoDrawing();
            aVideoDrawing.Rect = new Rect(0, 0, 700, 300);
            aVideoDrawing.Player = Media.VideoPlayer;
            Media.PlayVideo("video/frpg_opening.wmv");
        }

        private void media_MediaEnded(object sender, RoutedEventArgs e)
        {
            WorldMap worldMap = new WorldMap(this.GetLocation());
            worldMap.Show();
            this.Close();
        }
    }
}
