using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace Core.Classes
{
    public class MediaController
    {
        #region Поля
        private MediaPlayer MusicPlayer;
        private MediaPlayer SoundPlayer;
        public bool MainMenuMusicPlaying = false;
        #endregion
        #region Конструкторы
        public MediaController() 
        {
            MusicPlayer = new MediaPlayer();
            SoundPlayer = new MediaPlayer();
            UpdateVolume();
            Settings.MasterVolumeChanged += () => { UpdateVolume(); };
            Settings.MusicVolumeChanged += () => { UpdateMusicVolume(); };
            Settings.SoundVolumeChanged += () => { UpdateSoundVolume(); };
        }
        #endregion
        #region Методы
        private void UpdateSoundVolume() 
        {
            SoundPlayer.Volume = Settings.SoundVolume * Settings.MasterVolume;
        }

        private void UpdateMusicVolume()
        {
            MusicPlayer.Volume = Settings.MusicVolume * Settings.MasterVolume;
        }

        private void UpdateVolume()
        {
            UpdateSoundVolume();
            UpdateMusicVolume();
        }

        public void SetMusic(Uri path) 
        {
            MusicPlayer.Open(path);
        }
        public void PlayMusic() 
        {
            MusicPlayer.Play();
            MusicPlayer.MediaEnded += (s, e) => { MusicPlayer.Position = new TimeSpan(0); };
        }

        public void StopMusic() 
        {
            MusicPlayer.Pause();
            MusicPlayer.Position = new TimeSpan(0);
        }

        public void PauseMusic()
        {
            MusicPlayer.Pause();
        }

        public void SetSound(Uri path) 
        {
            SoundPlayer.Open(path);
        }

        public void PlaySound() 
        {
            SoundPlayer.Play();
        }
        #endregion
    }
}
