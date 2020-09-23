using DSRPG.Classes.Hero;
using DSRPG.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Core
{   
    public class Settings
    {
        #region Поля
        private static double musicVolume = 0.1;
        private static double soundVolume = 0.1;
        private static double masterVolume = 0.1;
        private static double videoVolume = 0.1;

        public static PageController PageController = new PageController();
        public static MediaController MediaController;

        public static HeroBase Hero;
        public static int TradeCost = 100;
        public static int BlacksmithCost = 200;

        public static LotrikViewModel Lotrik;
        private static int positionInCompaign = 0;

        private static bool heroPageIsOpened = false;
        #endregion
        #region Свойства
        public static double MusicVolume
        {
            get
            {
                return musicVolume;
            }

            set
            {
                musicVolume = value >= 0.0 && value <= 1.0 ? value : value > 1.0 ? 1.0 : 0.0;
                MusicVolumeChanged?.Invoke();
            }
        }
        public static double SoundVolume
        {
            get
            {
                return soundVolume;
            }

            set
            {
                soundVolume = value >= 0.0 && value <= 1.0 ? value : value > 1.0 ? 1.0 : 0.0;
                SoundVolumeChanged?.Invoke();
            }
        }
        public static double MasterVolume
        {
            get
            {
                return masterVolume;
            }

            set
            {
                masterVolume = value >= 0.0 && value <= 1.0 ? value : value > 1.0 ? 1.0 : 0.0;
                MasterVolumeChanged?.Invoke();
            }
        }

        public static double VideoVolume
        {
            get
            {
                return videoVolume;
            }

            set
            {
                videoVolume = value >= 0.0 && value <= 1.0 ? value : value > 1.0 ? 1.0 : 0.0;
                VideoVolumeChanged?.Invoke();
            }
        }

        public static int PositionInCompaign
        {
            get
            {
                return positionInCompaign;
            }

            set
            {
                if (value < 0 || value > 8) return;
                positionInCompaign = value;
                PositionChanged?.Invoke();
            }
        }

        public static bool HeroPageIsOpened 
        {
            get 
            {
                return heroPageIsOpened;
            }

            set 
            {
                heroPageIsOpened = value;
                HeroPageStateChanged?.Invoke();
            }
        }
        #endregion
        #region Делегаты и события
        public delegate void Changed();

        public static event Changed MusicVolumeChanged;
        public static event Changed SoundVolumeChanged;
        public static event Changed MasterVolumeChanged;
        public static event Changed VideoVolumeChanged;
        public static event Changed PositionChanged;
        public static event Changed HeroPageStateChanged;
        #endregion
        #region Методы
        #endregion
    }
}
