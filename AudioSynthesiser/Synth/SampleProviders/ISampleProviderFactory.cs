using AudioSynthesiser.Model;
using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    public interface ISampleProviderFactory
    {
        Oscillator Oscillator { get; set; }
        Oscillator Lfo { get; set; }
        Filter Filter { get; set; }
        float Volume { get; set; }

        ISampleProvider BuildSampleProvider();
    }
}
