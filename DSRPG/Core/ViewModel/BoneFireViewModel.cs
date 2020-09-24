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
using System.Windows.Data;

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

            Blacksmith.WeaponUpgrade.MouseEnter += label_MouseEnter;
            Blacksmith.WeaponUpgrade.MouseLeave += label_MouseLeave;
            Blacksmith.WeaponUpgrade.MouseLeftButtonDown += WeaponUpgrade_MouseLeftButtonDown;

            Trader.Loaded += Trader_Loaded;

            Trader.Buy.MouseEnter += label_MouseEnter;
            Trader.Buy.MouseLeave += label_MouseLeave;
            Trader.Buy.MouseLeftButtonDown += Buy_MouseLeftButtonDown;

            page.intPlus.MouseLeftButtonDown += IntPlus_MouseLeftButtonDown;
            page.intMinus.MouseLeftButtonDown += IntMinus_MouseLeftButtonDown;
            page.strMinus.MouseLeftButtonDown += StrMinus_MouseLeftButtonDown;
            page.strPlus.MouseLeftButtonDown += StrPlus_MouseLeftButtonDown;
            page.agiMinus.MouseLeftButtonDown += AgiMinus_MouseLeftButtonDown;
            page.agiPlus.MouseLeftButtonDown += AgiPlus_MouseLeftButtonDown;
            page.staMinus.MouseLeftButtonDown += StaMinus_MouseLeftButtonDown;
            page.staPlus.MouseLeftButtonDown += StaPlus_MouseLeftButtonDown;

            page.intPlus.MouseEnter += label_MouseEnter;
            page.intPlus.MouseLeave += label_MouseLeave;
            page.intMinus.MouseEnter += label_MouseEnter;
            page.intMinus.MouseLeave += label_MouseLeave;
            page.strPlus.MouseEnter += label_MouseEnter;
            page.strPlus.MouseLeave += label_MouseLeave;
            page.strMinus.MouseEnter += label_MouseEnter;
            page.strMinus.MouseLeave += label_MouseLeave;
            page.agiPlus.MouseEnter += label_MouseEnter;
            page.agiPlus.MouseLeave += label_MouseLeave;
            page.agiMinus.MouseEnter += label_MouseEnter;
            page.agiMinus.MouseLeave += label_MouseLeave;
            page.staPlus.MouseEnter += label_MouseEnter;
            page.staPlus.MouseLeave += label_MouseLeave;
            page.staMinus.MouseEnter += label_MouseEnter;
            page.staMinus.MouseLeave += label_MouseLeave;
        }

        private void Buy_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Trader.BuyCost) 
            {
                Core.Settings.Hero.Souls -= Trader.BuyCost;
                Core.Settings.Hero.Inv.GetRandomItem();
                Trader.BuyCost = Convert.ToInt32(Trader.BuyCost * 1.1);
                Core.Settings.TradeCost = Convert.ToInt32(Core.Settings.TradeCost * 1.1);
                Trader.BuyString.Content = $"Могу предложить {Environment.NewLine}рандомную фигню за {Environment.NewLine}{Trader.BuyCost} единицы душ";
            }
        }

        private void Trader_Loaded(object sender, RoutedEventArgs e)
        {
            Trader.BuyCost = Core.Settings.TradeCost;
            Trader.BuyString.Content = $"Могу предложить {Environment.NewLine}рандомную фигню за {Environment.NewLine}{Trader.BuyCost} единицы душ";
        }

        private void Blacksmith_Loaded(object sender, RoutedEventArgs e)
        {
            Blacksmith.WeaponCost = Core.Settings.BlacksmithCost;
            Blacksmith.WeaponString.Content = $"Прокачка оружия будет стоить {Environment.NewLine}{Blacksmith.WeaponCost} единицы душ";
        }


        private void WeaponUpgrade_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Inv.Weapon != -1 && Core.Settings.Hero.Souls >= Blacksmith.WeaponCost) 
            {
                Weapon weapon = Core.Settings.Hero.Inv.GetItem(Core.Settings.Hero.Inv.Weapon) as Weapon;
                weapon.Damage += rand.Next(1, 10);
                Core.Settings.Hero.Souls -= Blacksmith.WeaponCost;
                Core.Settings.Hero.Inv.WeaponUpgrade(weapon);
                Blacksmith.WeaponCost = Convert.ToInt32(Blacksmith.WeaponCost * 1.3);
                Core.Settings.BlacksmithCost = Convert.ToInt32(Core.Settings.BlacksmithCost * 1.3);
                Blacksmith.WeaponString.Content = $"Прокачка оружия будет стоить {Environment.NewLine}{Blacksmith.WeaponCost} единицы душ";
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

            page.strLabel.DataContext = Core.Settings.Hero;
            page.agiLabel.DataContext = Core.Settings.Hero;
            page.staLabel.DataContext = Core.Settings.Hero;
            page.intLabel.DataContext = Core.Settings.Hero;
        }

        private void StaPlus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost) 
            {
                Core.Settings.Hero.Stamina++;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
        }

        private void StaMinus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost)
            {
                Core.Settings.Hero.Stamina--;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
        }

        private void AgiPlus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost)
            {
                Core.Settings.Hero.Agility++;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
        }

        private void AgiMinus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost)
            {
                Core.Settings.Hero.Agility--;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
        }

        private void StrPlus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost)
            {
                Core.Settings.Hero.Strength++;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
        }

        private void StrMinus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost)
            {
                Core.Settings.Hero.Strength--;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
        }

        private void IntMinus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost)
            {
                Core.Settings.Hero.Intellect--;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
        }

        private void IntPlus_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Core.Settings.Hero.Souls >= Core.Settings.UpgradeCost)
            {
                Core.Settings.Hero.Intellect++;
                Core.Settings.Hero.Souls -= Core.Settings.UpgradeCost;
                Core.Settings.Hero.ReCaclCost();
                Core.Settings.Hero.UpdateStats();
            }
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
