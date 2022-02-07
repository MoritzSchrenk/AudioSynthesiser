using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    /// <summary>
    /// Abstract class for ISampleProviders that decorate another ISampleProvider
    /// </summary>
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
