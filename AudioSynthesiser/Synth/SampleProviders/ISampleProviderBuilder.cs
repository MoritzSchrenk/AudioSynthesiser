using AudioSynthesiser.Model;
using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{

    /// <summary>
    /// configures components and creates a sample provider from them
    /// </summary>
    public interface ISampleProviderBuilder
    {
        public ISampleProviderBuilder WithSignalGenerator(Oscillator oscillator);
        public ISampleProviderBuilder WithLfo(Oscillator lfo);
        public ISampleProviderBuilder WithFilter(Filter filter);
        public ISampleProviderBuilder WithEnvelope(Adsr adsr);
        public ISampleProviderBuilder WithVolume(float volume);

        ISampleProvider GetSampleProvider();
    }
}
