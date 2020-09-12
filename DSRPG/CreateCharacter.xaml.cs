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
using static Core.Core;

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
            if(man.IsChecked == true)
            {
                MessageBox.Show("Вы выбрали man");
            }
            else
            {
                MessageBox.Show("Вы выбрали female");
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

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Введите имя";
                Name.Foreground = Brushes.White;
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name.MaxLength = 10;
        }
        //Типо есть реализация русского и английского языка
        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
          
            char q = Convert.ToChar(e.Text);
            string s = e.Text;
            byte[] bytes = Encoding.GetEncoding(1251).GetBytes(s);
            if (q <= 97 && q <= 64 && Convert.ToChar(s) <= 191 || q >= 123 && q >=91 && Convert.ToChar(s) <= 256)
            {
                e.Handled = true;
                MessageBox.Show("Ввод только символов !","Ошибка");
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Warrior.IsSelected)
                infoclasses.Text = "Инфа о Воине";
            else if (archer.IsSelected)
                infoclasses.Text = "Инфа о Лучнике";
            else if (Paladin.IsSelected)
                infoclasses.Text = "Инфа о Паладине";
            else if (Mage.IsSelected)
                infoclasses.Text = "Инфа о Маге";
        }

        private void accept_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Media.StopMusic();
            HistoryOfDS history = new HistoryOfDS(this.GetLocation());
            history.Show();
            Close();
        }

        private void accept_MouseEnter(object sender, MouseEventArgs e)
        {
            accept.Foreground = Brushes.Yellow;
        }

        private void accept_MouseLeave(object sender, MouseEventArgs e)
        {
            accept.Foreground = Brushes.White;
        }

        private void back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow(this.GetLocation());
            main.Show();
            Close();
        }

        private void back_MouseEnter(object sender, MouseEventArgs e)
        {
            back.Foreground = Brushes.Yellow;
        }

        private void back_MouseLeave(object sender, MouseEventArgs e)
        {
            back.Foreground = Brushes.White;
        }

        private void archer_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
    }
}
