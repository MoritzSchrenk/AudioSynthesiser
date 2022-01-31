using NAudio.Wave;

namespace AudioSynthesiser.Synth
{
    public abstract class AbstractSourceProviderDecorator : ISampleProvider
    {
        protected ISampleProvider SourceProvider { get; }

        public WaveFormat WaveFormat => SourceProvider.WaveFormat;

        public AbstractSourceProviderDecorator(ISampleProvider sampleProvider)
        {
            SourceProvider = sampleProvider;
        }
        public abstract int Read(float[] buffer, int offset, int count);
    }
}
