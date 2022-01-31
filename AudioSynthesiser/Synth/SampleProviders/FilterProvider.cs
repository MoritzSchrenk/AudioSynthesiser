using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    public class FilterProvider : AbstractSampleProviderDecorator
    {
        private readonly IFilter filter;

        public FilterProvider(ISampleProvider sourceProvider, IFilter filter) : base(sourceProvider)
        {
            this.filter = filter;
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = SourceProvider.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                buffer[offset + n] = filter.Transform(buffer[offset + n]);
            }

            return samplesRead;
        }
    }
}