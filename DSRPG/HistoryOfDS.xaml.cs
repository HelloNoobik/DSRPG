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
    }
}
