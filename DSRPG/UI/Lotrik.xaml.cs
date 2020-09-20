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
using DSRPG.GameLogic.Mobs;
using DSRPG.Test;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для Lotrik.xaml
    /// </summary>
    public partial class Lotrik : Page
    {
        public Lotrik()
        {
            InitializeComponent();
            
        }

        private void back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Settings.PageController.ChangeWindow(Pages.WorldMap);
        }

        private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Settings.PageController.ChangeWindow(Pages.BattleArena);
        }
    }
}
