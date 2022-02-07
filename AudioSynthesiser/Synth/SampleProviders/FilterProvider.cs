using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    /// <summary>
    /// Wraps a sample provider in a filter
    /// </summary>
    public class FilterProvider : AbstractSampleProviderDecorator
    {
        private readonly IFilter _filter;

        public FilterProvider(ISampleProvider sourceProvider, IFilter filter) : base(sourceProvider)
        {
            this._filter = filter;
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = SourceProvider.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                buffer[offset + n] = _filter.Transform(buffer[offset + n]);
            }

            return samplesRead;
        }
    }
}