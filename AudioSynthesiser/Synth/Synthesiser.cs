using NAudio.Wave;
using System;

namespace AudioSynthesiser.Synth
{
    public class Synthesiser : ISynthesiser
    {
        private ISampleProvider _sampleProvider;
        private readonly WaveOutEvent _waveOut;
        private bool _isPlaying;

        private bool _stopped;


        public Synthesiser()
        {
            _waveOut = new WaveOutEvent();
            _waveOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(OnStoppedPlaying);
            _stopped = true;
        }

        public void SetSampleProvider(ISampleProvider sampleProvider)
        {
            _sampleProvider = sampleProvider;
        }

        public void Play()
        {
            if (_sampleProvider == null)
            {
                Stop();
                return;
            }

            if (_isPlaying)
            {
                _waveOut.Stop();
            }

            _waveOut.Init(_sampleProvider);
            _waveOut.Play();
            PlaybackMediator.OnStartPlaying();
            _isPlaying = true;
            _stopped = false;
        }

        public void Update()
        {
            if (!_stopped)
            {
                Play();
            }
        }

        public void Stop()
        {
            if (!_stopped)
            {
                _stopped = true;
                PlaybackMediator.OnStopPlaying();
            }
        }

        private void OnStoppedPlaying(object sender, StoppedEventArgs e)
        {
            _isPlaying = false;
        }
    }
}
