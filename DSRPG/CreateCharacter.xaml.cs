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
    /// Логика взаимодействия для CreateCharacter.xaml
    /// </summary>
    public partial class CreateCharacter : Window
    {
        public CreateCharacter()
        {
            InitializeComponent();
            Name.MaxLength = 10;
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            if(Name.Text == "Введите имя")
            {
                Name.Text = "";
                Name.Foreground = Brushes.Black;
            }
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Введите имя";
                Name.Foreground = Brushes.Gray;
            }
        }
    }
}
