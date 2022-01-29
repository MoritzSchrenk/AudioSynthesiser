using NAudio.Wave;

namespace AudioSynthesiser.ViewModel
{
    public class LfoProvider : ISampleProvider
    {
        private ISampleProvider _sourceProvider;
        private ISampleProvider _lfo;

        public LfoProvider(ISampleProvider provider, ISampleProvider lfo)
        {
            _sourceProvider = provider;
            _lfo = lfo;
        }

        public WaveFormat WaveFormat => _sourceProvider.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = _sourceProvider.Read(buffer, offset, count);
            var lfoBuffer = new float[count];
            _ = _lfo.Read(lfoBuffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                buffer[offset + n] += buffer[offset + n] * lfoBuffer[offset + n];
            }

            return samplesRead;

        }
    }
}
