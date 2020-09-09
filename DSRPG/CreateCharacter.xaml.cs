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
        }

        private void Name_TouchEnter(object sender, TouchEventArgs e)
        {
            if(Name.Text == "Введите имя")
            {
                Name.Text = "";
            }
        }

        private void Name_TouchLeave(object sender, TouchEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Введите имя";
            }
        }
    }
}
