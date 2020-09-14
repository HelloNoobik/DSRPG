using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DSRPG.UI.CreateHeroPageUI;
using System.Threading;
using System.Windows;

namespace DSRPG.GameLogic.ViewModel
{
    class CreateCharacterViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private NamePage Name;
        private GenderPage Gender;
        private ClassPage Class;
        private GiftPage Gift;

        private Page currentPage;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }

            set
            {
                if (value == currentPage) return;
                currentPage = value;
                OnPropertyChanged();
            }
        }

        private double pageOpacity;
        public double PageOpacity
        {
            get
            {
                return pageOpacity;
            }

            set
            {
                if (value >= 0.0 && value <= 1.0) pageOpacity = value;
                else if (value < 0.0) pageOpacity = 0.0;
                else pageOpacity = 1.0;
                OnPropertyChanged();
            }
        }

        public CreateCharacterViewModel() 
        {
            Name = new NamePage();
            Gender = new GenderPage();
            Class = new ClassPage();
            Gift = new GiftPage();

            PageOpacity = 1.0;
            CurrentPage = null;
        }

        public void ChangePage(string str) 
        {
            switch (str) 
            {
                case "Name":
                    SlowOpacity(Name);
                    break;
                case "Gender":
                    SlowOpacity(Gender);
                    break;
                case "Class":
                    SlowOpacity(Class);
                    break;
                case "Gift":
                    SlowOpacity(Gift);
                    break;
                default:
                    MessageBox.Show("Окно не найдено!");
                    break;
            }
        }

        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                if (currentPage != null) 
                { 
                    for (double i = 1.0; i > 0.0; i -= 0.1)
                    {
                        PageOpacity = i;
                        Thread.Sleep(10);
                    }    
                }

                CurrentPage = page;

                for (double i = 0.0; i < 1.0; i += 0.1)
                {
                    PageOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }

        public Character Check() 
        {
            Character result = null;
            if (IsCorrect()) return new Character(Name.GetResult(), Class.GetResult(), Gender.GetResult(), Gift.GetResult());
            return result; 
        }

        private bool IsCorrect() 
        {
            if (Name.GetResult().Length == 0 || Gender.GetResult().Length == 0 || Class.GetResult().Length == 0 || Gift.GetResult().Length == 0) return false;
            return true;
        }
    }
}
