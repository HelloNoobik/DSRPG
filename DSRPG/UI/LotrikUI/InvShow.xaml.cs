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

namespace DSRPG.UI.LotrikUI
{
    /// <summary>
    /// Логика взаимодействия для InvShow.xaml
    /// </summary>
    public partial class InvShow : Page
    {
        public InvShow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Core.Settings.HeroPageIsOpened = true;
            Core.Settings.Lotrik.ChangePage("Show");
        }
    }
}
