using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DSRPG.Classes;

namespace DSRPG.Core.ViewModel
{
    class BoneFireViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Random rand;

        private UI.BoneFirePage page;
        private UI.BoneFireUI.BlacksmithPage Blacksmith;
        private UI.BoneFireUI.TraderPage Trader;

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

        public BoneFireViewModel(UI.BoneFirePage page)
        {
            rand = new Random();
            this.page = page;
            Blacksmith = new UI.BoneFireUI.BlacksmithPage();
            Trader = new UI.BoneFireUI.TraderPage();

            PageOpacity = 1.0;
            CurrentPage = null;

            page.Loaded += Page_Loaded;
            page.Blacksmith.MouseLeftButtonDown += Blacksmith_MouseLeftButtonDown;
            page.Trader.MouseLeftButtonDown += Trader_MouseLeftButtonDown;
            page.Rest.Click += Rest_Click;
            page.Back.Click += Back_Click;

            Blacksmith.Loaded += Blacksmith_Loaded;
            Blacksmith.Back.MouseEnter += label_MouseEnter;
            Blacksmith.Back.MouseLeave += label_MouseLeave;
            Blacksmith.Back.MouseLeftButtonDown += BlacksmithBack_MouseLeftButtonDown;

            Blacksmith.WeaponUpgrade.MouseEnter += label_MouseEnter;
            Blacksmith.WeaponUpgrade.MouseLeave += label_MouseLeave;
            Blacksmith.WeaponUpgrade.MouseLeftButtonDown += WeaponUpgrade_MouseLeftButtonDown;

            Trader.Loaded += Trader_Loaded;
            Trader.Back.MouseEnter += label_MouseEnter;
            Trader.Back.MouseLeave += label_MouseLeave;
            Trader.Back.MouseLeftButtonDown += TraderBack_MouseLeftButtonDown;

            Trader.Buy.MouseEnter += label_MouseEnter;
            Trader.Buy.MouseLeave += label_MouseLeave;
            Trader.Buy.MouseLeftButtonDown += Buy_MouseLeftButtonDown;
        }

        private void Buy_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Trader.BuyCost) 
            {
                Core.Settings.Hero.Souls -= Trader.BuyCost;
                Core.Settings.Hero.inv.GetRandomItem();
            }
        }

        private void Trader_Loaded(object sender, RoutedEventArgs e)
        {
            Trader.BuyCost = rand.Next(52, 162);
            Trader.BuyString.Content = $"Могу предложить рандомную фигню за {Trader.BuyCost} душ";
        }

        private void Blacksmith_Loaded(object sender, RoutedEventArgs e)
        {
            Blacksmith.WeaponCost = rand.Next(52, 162);

            Blacksmith.WeaponString.Content = $"Прокачка оружия будет стоить {Blacksmith.WeaponCost} душ";
        }

        private void TraderBack_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentPage = null;
        }

        private void WeaponUpgrade_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.inv.Weapon != -1 && Core.Settings.Hero.Souls >= Blacksmith.WeaponCost) 
            {
                Weapon weapon = Core.Settings.Hero.inv.GetItem(Core.Settings.Hero.inv.Weapon) as Weapon;
                weapon.Damage += rand.Next(1, 10);
                Core.Settings.Hero.Souls -= Blacksmith.WeaponCost;
                Core.Settings.Hero.inv.WeaponUpgrade(weapon);
            }
        }

        private void BlacksmithBack_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CurrentPage = null;
        }

        private void label_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (sender as Label).Foreground = Brushes.Yellow;
        }

        private void label_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            (sender as Label).Foreground = Brushes.White;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Core.Settings.PageController.ChangeWindow(Pages.Lotrik);
        }

        private void Rest_Click(object sender, RoutedEventArgs e)
        {
            Core.Settings.Hero.Rest();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            page.DataContext = this;
            page.souls.DataContext = Core.Settings.Hero;
        }

        private void Trader_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SlowOpacity(Trader);
        }

        private void Blacksmith_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SlowOpacity(Blacksmith);
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
    }
}
