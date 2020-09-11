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
        public CreateCharacter(Point point)
        {
            this.SetLocation(point);
            InitializeComponent();
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
                Name.Foreground = Brushes.White;
            }
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Введите имя";
                //Name.Foreground = Brushes.White;
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name.MaxLength = 10;
        }

        private void Name_PreviewKeyDown(object sender, KeyEventArgs e)
        {//Тест
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) & e.Key != Key.Back | e.Key == Key.Space)
            {
                e.Handled = true;
                MessageBox.Show("I only accept numbers, sorry. :(", "This textbox says...");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(this.GetLocation());
            mainWindow.Show();
            this.Close();
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HistoryOfDS window = new HistoryOfDS(this.GetLocation());
            window.Show();
            this.Close();
        }
    }
}
