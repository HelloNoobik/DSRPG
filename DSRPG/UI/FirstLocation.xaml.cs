using DSRPG.UI;
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
    /// Логика взаимодействия для FirstLocation.xaml
    /// </summary>
    public partial class FirstLocation : Window
    {
        public FirstLocation(Point point)
        {
            this.SetLocation(point);
            InitializeComponent();
        }

        private void back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WorldMap world = new WorldMap(this.GetLocation());
            world.Show();
            Close();
        }

        private void  PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            FightArena figth = new FightArena(this.GetLocation());
            figth.Show();
            Close();
        }
    }
}
