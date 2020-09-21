using DSRPG.UI;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DSRPG
{
    public enum Pages
    {
        Main,
        Intro,
        Settings,
        BattleArena,
        CreateCharacter,
        Lotrik,
        WorldMap,
    }
}

namespace DSRPG.Core
{
    public class PageController : ViewModelBase, INotifyPropertyChanged
    {
        #region Event PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region Поля
        private Page Main;
        private Page Intro;
        private Page Settings;
        private Page BattleArena;
        private Page CreateCharacter;
        private Page Lotrik;
        private Page WorldMap;
        private Page Load;
        private Page Test;

        private Page currentPage;

        private double pageOpacity;
        #endregion
        #region Свойства
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
        #endregion
        #region Конструкторы
        public PageController()
        {
            Main = new UI.MainMenu();
            Intro = new UI.Intro();
            Settings = new UI.SettingsPage();
            BattleArena = null;
            CreateCharacter = new UI.CreateCharacter();
            Lotrik = new UI.Lotrik();
            WorldMap = new UI.WorldMap();
            Load = new UI.Load();
            Test = null;

            CurrentPage = Load;

            PageOpacity = 1.0;
        }
        #endregion
        #region Методы
        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    PageOpacity = i;
                    Thread.Sleep(10);
                }

                CurrentPage = page;

                for (double i = 0.0; i < 1.0; i += 0.1)
                {
                    PageOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }

        public void ChangeWindow(Pages page)
        {
            Page _page = null;
            switch (page)
            {
                case Pages.Main:
                    _page = Main;
                    break;
                case Pages.Intro:
                    _page = Intro;
                    break;
                case Pages.Settings:
                    _page = Settings;
                    break;
                case Pages.BattleArena:
                    BattleArena = new BattleArena();
                    _page = BattleArena;
                    break;
                case Pages.CreateCharacter:
                    _page = CreateCharacter;
                    break;
                case Pages.Lotrik:
                    _page = Lotrik;
                    break;
                case Pages.WorldMap:
                    _page = WorldMap;
                    break;
            }
            SlowOpacity(_page);
        }
        #endregion
    }
}
