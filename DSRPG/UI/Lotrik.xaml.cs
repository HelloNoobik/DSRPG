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
using DSRPG.Classes.Company;
using DSRPG.Classes.Hero;
using DSRPG.Core;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для Lotrik.xaml
    /// </summary>
    public partial class Lotrik : Page
    {
        static public List<Point> points = new List<Point>()
        {
            new Point(386,55),
            new Point(438,110),
            new Point(478,166),
            new Point(426,218),
            new Point(386,166),
            new Point(329,158),
            new Point(277,209),
            new Point(300,265),
        };
        static private List<Level> levels = new List<Level>();
        public Lotrik()
        {  
            InitializeComponent();
            Core.Settings.Lotrik = new Core.ViewModel.LotrikViewModel(this);
            DataContext = Core.Settings.Lotrik;

           
            for (int i = 0; i < points.Count; i++) 
            {
                Level level = new Level(i,points[i],this);
                levels.Add(level);
            }

        }

        private void back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Settings.PageController.ChangeWindow(Pages.WorldMap);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings.PositionInCompaign++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Settings.PositionInCompaign--;
        }
    }
}
