using NAudio.Wave;

namespace AudioSynthesiser.Synth
{
    public class Synthesiser : ISynthesiser
    {
        private ISampleProvider _sampleProvider;
        private WaveOutEvent wo;

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

            if (wo == null)
            {
                wo = new WaveOutEvent();
            }
            else
            {
                wo.Stop();
            }

            wo.Init(_sampleProvider);
            wo.Play();
        }

        public void Update()
        {
            if (wo != null)
            {
                Play();
            }
        }

        public void Stop()
        {
            if (wo != null)
            {
                wo.Stop();
                wo = null;
            }
        }
    }
}
