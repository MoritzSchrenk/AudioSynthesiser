using NAudio.Wave;
using System;

namespace AudioSynthesiser.Synth
{
    public class Synthesiser : ISynthesiser
    {
        private ISampleProvider _sampleProvider;
        private readonly WaveOutEvent _waveOut;
        public bool IsPlaying { get; private set; }


        public Synthesiser()
        {
            _waveOut = new WaveOutEvent();
            _waveOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(OnStoppedPlaying);
        }

        public void SetSampleProvider(ISampleProvider sampleProvider)
        {
            _sampleProvider = sampleProvider;
        }

        public void Play()
        {
            if(_sampleProvider == null)
            {
                Stop();
                return;
            }

            if (IsPlaying)
            {
                _waveOut.Stop();
            }

            _waveOut.Init(_sampleProvider);
            _waveOut.Play();
            PlaybackMediator.OnStartPlaying();
            IsPlaying = true;
        }

        public void Update()
        {
            if (IsPlaying)
            {
                Play();
            }
        }

        public void Stop()
        {
            if (IsPlaying)
            {
                PlaybackMediator.OnStopPlaying();
            }
        }

        private void OnStoppedPlaying(object sender, StoppedEventArgs e)
        {
            IsPlaying = false;
        }
    }
}
