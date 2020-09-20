using DSRPG.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для Load.xaml
    /// </summary>
    public partial class Load : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int _value = 0;
        private string status = "";
        public int Value 
        {
            get 
            {
                return _value;
            }
            set 
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        public string Status 
        {
            get 
            {
                return status;
            }

            set 
            {
                status = value;
                OnPropertyChanged();
            }
        }
        public Load()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            pb.Maximum = 2;

            Work();
        }

        private async void Work() 
        {
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            await Task.Factory.StartNew(() => 
            {
                Status = "Инициализация классов";

                dispatcher.InvokeAsync(() => 
                { 
                    Core.Settings.MediaController = new Core.MediaController();
                });
                Value++;
                Thread.Sleep(1000);

                Status = "Загрузка предметов";
                Inventory.Load();
                Value++;
                Thread.Sleep(1000);

                Status = "Готово";
                Thread.Sleep(1000);
            });

            Core.Settings.PageController.ChangeWindow(Pages.Main);
        }
    }
}
