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

namespace DSRPG.UI.CreateHeroPageUI
{
    /// <summary>
    /// Логика взаимодействия для NamePage.xaml
    /// </summary>
    public partial class NamePage : Page
    {
        public NamePage()
        {
            InitializeComponent();
            Name.MaxLength = 10;
        }

        public string GetResult()
        {
            return Name.Text.ToString();
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Введите имя";
                Name.Foreground = Brushes.White;
            }
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "Введите имя")
            {
                Name.Text = "";
                Name.Foreground = Brushes.AntiqueWhite;
            }
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char q = Convert.ToChar(e.Text);
            string s = e.Text;
            byte[] bytes = Encoding.GetEncoding(1251).GetBytes(s);
            if (q <= 97 && q <= 64 && Convert.ToChar(s) <= 191 || q >= 123 && q >= 91 && Convert.ToChar(s) <= 256)
            {
                e.Handled = true;
                MessageBox.Show("Ввод только символов !", "Ошибка");
            }
        }
    }
}
