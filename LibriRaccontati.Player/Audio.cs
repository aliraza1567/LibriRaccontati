using NAudio.Wave;
using System;
using System.IO;

namespace LibriRaccontati.Player
{
    public class Audio
    {

        public enum PlayBackState
        {
            Stopped = 0,
            Playing = 1,
            Paused = 2
        }
        public event ErrorOccuredHandle Error;
        public delegate void ErrorOccuredHandle(string functionName, string errorMessage, string errorStach);
        public event PlayStopHandle PlaybackStop;
        public delegate void PlayStopHandle(EventArgs e);
        private IWavePlayer _waveOutDevice;
        private WaveStream _mainOutputStream;
        private WaveChannel32 _volumeStream;
        private bool _isDispose;
        public TimeSpan TotalDuration
        {
            get
            {
                if (_mainOutputStream != null)
                    return _mainOutputStream.TotalTime;
                return new TimeSpan();
            }
        }
        public string TotalTime
        {
            get
            {
                if (_mainOutputStream != null)
                    return String.Format("{0:00}:{1:00}", (int)_mainOutputStream.TotalTime.TotalMinutes, _mainOutputStream.TotalTime.Seconds);
                return "00:00";
            }
        }
        public TimeSpan TimePosition
        {
            get
            {
                if (_mainOutputStream == null) return TimeSpan.Zero;

                return _mainOutputStream.CurrentTime;
            }
            set { _mainOutputStream.CurrentTime = value; }

        }
        public void Pause()
        {
            if (_waveOutDevice == null) return;
            _waveOutDevice.Pause();
        }
        public void Play()
        {

            if (_waveOutDevice == null) return;

            if (_waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                return;
            }

            _waveOutDevice.Play();

        }
        public void Stop()
        {
            _waveOutDevice.Stop();
        }
        public float Volume
        {
            get { return _volumeStream.Volume; }
            set
            {
                if (_volumeStream != null)
                    _volumeStream.Volume = value;
            }
        }
        public float Pan
        {
            get { return _volumeStream.Pan; }
            set
            {
                if (_volumeStream != null)
                    _volumeStream.Pan = value;
            }
        }
        public PlayBackState State
        {
            get
            {
                if (_waveOutDevice != null)
                    return (PlayBackState)_waveOutDevice.PlaybackState;
                return PlayBackState.Stopped;
            }
        }
        public Audio(string fileName)
        {
            if (!File.Exists(fileName)) return;
            _waveOutDevice = new WaveOut();

            try
            {
                _mainOutputStream = CreateInputStream(fileName);

                if (_mainOutputStream == null)
                {
                    throw new InvalidOperationException("Unsupported file extension");
                }

            }
            catch (Exception createException)
            {
                if (Error != null)
                    Error("Audio - Play - CreateInputStream", createException.Message, createException.StackTrace);
                return;
            }

            try
            {
                _waveOutDevice.Init(_mainOutputStream);
            }
            catch (Exception initException)
            {
                if (Error != null)
                    Error("Audio - Play - Init", initException.Message, initException.StackTrace);
                return;
            }

            _waveOutDevice.PlaybackStopped += _waveOutDevice_PlaybackStopped;
        }
        private void _waveOutDevice_PlaybackStopped(object sender, EventArgs e)
        {

            if (PlaybackStop != null)
                PlaybackStop(e);
        }
        public void Dispose()
        {
            _waveOutDevice?.Stop();
            if (_mainOutputStream != null)
            {
                _volumeStream.Close();
                _volumeStream = null;
                _mainOutputStream.Close();
                _mainOutputStream = null;
            }
            if (_waveOutDevice != null)
            {
                _waveOutDevice.Dispose();
                _waveOutDevice = null;
            }
            GC.Collect();
            _isDispose = true;
        }
        ~Audio()
        {
            if (!_isDispose)
                Dispose();

        }
        private WaveStream CreateInputStream(string fileName)
        {
            WaveStream reader = CreateReaderStream(fileName);

            if (reader == null)
            {
                throw new InvalidOperationException("Unsupported extension");
            }

            _volumeStream = new WaveChannel32(reader);
            return _volumeStream;
        }
        private WaveStream CreateReaderStream(string fileName)
        {
            WaveStream readerStream = null;
            if (fileName.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
            {
                readerStream = new WaveFileReader(fileName);
                if (readerStream.WaveFormat.Encoding != WaveFormatEncoding.Pcm && readerStream.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
                {
                    readerStream = WaveFormatConversionStream.CreatePcmStream(readerStream);
                    readerStream = new BlockAlignReductionStream(readerStream);
                }
            }
            else if (fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
            {
                readerStream = new Mp3FileReader(fileName);
            }
            else if (fileName.EndsWith(".aiff"))
            {
                readerStream = new AiffFileReader(fileName);
            }
            return readerStream;
        }
    }
}
