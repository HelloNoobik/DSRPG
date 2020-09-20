using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using DSRPG;

namespace DSRPG.Core
{
    public class MediaController
    {
        #region Поля
        private MediaPlayer MusicPlayer;
        private MediaPlayer SoundPlayer;

        public bool MainMenuMusicPlaying = false;
        public bool WorldMusicPlaying = false;
        private bool SoundPlayerBusy = false;
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
            SoundPlayer.MediaOpened += (s,e) => { SoundPlayerBusy = true; };
            SoundPlayer.MediaEnded += (s,e) => { SoundPlayerBusy = false; };
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

        public void PlayMusic(Uri path)
        {
            MusicPlayer.MediaFailed += (s, e) => { MessageBox.Show($"ПИЗДА ДОРОЖКЕ! {e.ErrorException}"); };
            MusicPlayer.Open(path);
            MusicPlayer.Position = new TimeSpan(0);
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

        public void ResumeMusic()
        {
            MusicPlayer.Play();
        }

        public void PlaySound(Uri path)
        {
            if (!SoundPlayerBusy)
            {
                SoundPlayer.MediaFailed += (s, e) => { MessageBox.Show($"ПИЗДА ДОРОЖКЕ! {e.ErrorException}"); };
                SoundPlayer.Open(path);
                SoundPlayer.Play();
            }
        }
        #endregion
    }
}
