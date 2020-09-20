using DSRPG.Classes.Hero;
using GalaSoft.MvvmLight;
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

namespace DSRPG.Core.ViewModel
{
    public class LotrikViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private UI.Lotrik lotrik;

        private UI.LotrikUI.InvShow Hide;
        private UI.HeroPage Show;

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

        private Thickness framePosition;

        public Thickness FramePosition 
        {
            get 
            {
                return framePosition;
            }

            set 
            {
                framePosition = value;
                OnPropertyChanged();
            }
        }

        public LotrikViewModel(UI.Lotrik page)
        {
            lotrik = page;
            Hide = new UI.LotrikUI.InvShow();
            Show = new UI.HeroPage();

            FramePosition = new Thickness(46, 373, 0, -254);
            PageOpacity = 1.0;
            CurrentPage = Hide;
        }

        public void ChangePage(string str)
        {
            Page _page = null;
            switch (str)
            {
                case "Show":
                    _page = Show;
                    lotrik.back.Visibility = Visibility.Hidden;
                    break;
                case "Hide":
                    _page = Hide;
                    lotrik.back.Visibility = Visibility.Visible;
                    break;
                default:
                    MessageBox.Show("Окно не найдено!");
                    break;
            }
            SlowOpacity(_page);
            Animation(_page);
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

        private async void Animation(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                if (page == Show)
                {
                    for (double i = 373.0; i > 119.0; i -= 2) 
                    {
                        FramePosition = new Thickness(FramePosition.Left,i,0,0);
                        Thread.Sleep(10);
                    }
                }
                else 
                {
                    for (double i = 119.0; i < 373.0; i += 2)
                    {
                        FramePosition = new Thickness(FramePosition.Left, i, 0, 0);
                        Thread.Sleep(10);
                    }
                }
            });
        }
    }
}
