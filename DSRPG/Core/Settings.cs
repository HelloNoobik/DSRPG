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
        public static PageController PageController;
        public static MediaController MediaController = new MediaController();
        public static HeroBase Hero;

        public static LotrikViewModel Lotrik;
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
        #endregion
        #region Делегаты и события
        public delegate void Changed();

        public static event Changed MusicVolumeChanged;
        public static event Changed SoundVolumeChanged;
        public static event Changed MasterVolumeChanged;
        public static event Changed VideoVolumeChanged;
        #endregion
        #region Методы
        #endregion
    }
}
