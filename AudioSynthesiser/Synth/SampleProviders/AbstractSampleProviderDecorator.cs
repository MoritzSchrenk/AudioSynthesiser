using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    public abstract class AbstractSampleProviderDecorator : ISampleProvider
    {
        protected ISampleProvider SourceProvider { get; }

        public WaveFormat WaveFormat => SourceProvider.WaveFormat;

        public AbstractSampleProviderDecorator(ISampleProvider sampleProvider)
        {
            SourceProvider = sampleProvider;
        }
        public abstract int Read(float[] buffer, int offset, int count);
    }
}
