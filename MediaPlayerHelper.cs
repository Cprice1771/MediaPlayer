using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MediaPlayerHelper
{
    public class MediaPlayerHelper
    {

        private static MediaPlayerHelper instance;

        public static MediaPlayerHelper Instance
        {
            get
            {
                if(instance == null)
                    instance = new MediaPlayerHelper();

                return instance;
            }
        }

        public bool Loop
        {
            get
            {
                return _loop;
            }
            set 
            {
                _wplayer.settings.setMode("Loop", value);
                _loop = value;
            } 
        }

        bool _loop;
        System.Media.SoundPlayer _player;
        WMPLib.WindowsMediaPlayer _wplayer;
        bool _isPlaying;

        private MediaPlayerHelper()
        {
            _player = new System.Media.SoundPlayer();
            _wplayer = new WMPLib.WindowsMediaPlayer();
            Loop = false;
            _isPlaying = false;
            _wplayer.settings.volume = 5;
            
        }

        /// <summary>
        /// Plays a song, only 1 song can be played at a time and can be stopped using the Stop() method
        /// </summary>
        /// <param name="s">Song to play</param>
        public void Play(SongFile s)
        {
            if (!File.Exists(s.File))
                throw new FileNotFoundException("Unable to find the specified file, make sure you selected Copy Always in Visual Studio");



            if (_isPlaying)
            {
                _player.Stop();
                _wplayer.controls.stop();
            }

            if (Path.GetExtension(s.File) == ".wav")
            {
                _wplayer.URL = s.File;
                _wplayer.controls.play();
                _isPlaying = true;
            }
            else if (Path.GetExtension(s.File) == ".mp3")
            {
                _wplayer.URL = s.File;
                _wplayer.controls.play();
                _isPlaying = true;
            }
            else if (Path.GetExtension(s.File) == ".wma")
            {
                _wplayer.URL = s.File;
                _wplayer.controls.play();
                _isPlaying = true;
            }
            else
                throw new FileExtensionException("Unrecognized file extension, This library only supports .mp3, .wma, and .wav");
        }

        /// <summary>
        /// Stops the current song that is being played
        /// </summary>
        public void Stop()
        {
            if (_isPlaying)
            {
                _player.Stop();
                _wplayer.controls.stop();
            }
        }

        /// <summary>
        /// Plays a new sound independent from the normal sound logic. Playing a new sound will not cancel a song or sound.
        /// </summary>
        public void PlaySound(SongFile s)
        {
            if (!File.Exists(s.File))
                throw new FileNotFoundException("Unable to find the specified file, make sure you selected Copy Always in Visual Studio");

            MediaPlayer _effectPlayer = new MediaPlayer();
            _effectPlayer.Volume = 7;
            string ext = Path.GetExtension(s.File);
            if (ext == ".wav")
            {

                _effectPlayer.Open(new Uri(s.File));
                _effectPlayer.Play();

            }
            else if (Path.GetExtension(s.File) == ".mp3")
            {
                _effectPlayer.Open(new Uri(s.File));
                _effectPlayer.Play();
            }

            
        }

    }
}
