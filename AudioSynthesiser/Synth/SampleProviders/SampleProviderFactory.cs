using AudioSynthesiser.Model;
using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    public class SampleProviderFactory : ISampleProviderFactory
    {
        private readonly ISampleProviderBuilder _sampleProviderFactory;

        public Oscillator Oscillator { get; set; }
        public Oscillator Lfo { get; set; }
        public Filter Filter { get; set; }
        public float Volume { get; set; }


        public SampleProviderFactory(ISampleProviderBuilder sampleProviderFactory)
        {
            _sampleProviderFactory = sampleProviderFactory;
        }
        public ISampleProvider BuildSampleProvider()
        {
            return _sampleProviderFactory.WithSignalGenerator(Oscillator)
                .WithLfo(Lfo)
                .WithFilter(Filter)
                .WithVolume(Volume)
                .GetSampleProvider();
        }
    }
}
