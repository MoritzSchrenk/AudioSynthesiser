using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    public class LfoProvider : AbstractSampleProviderDecorator
    {
        private readonly ISampleProvider _lfo;

        public LfoProvider(ISampleProvider sourceProvider, ISampleProvider lfo) : base(sourceProvider)
        {
            _lfo = lfo;
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = SourceProvider.Read(buffer, offset, count);
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
