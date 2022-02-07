using AudioSynthesiser.Model;
using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    /// <summary>
    /// Gets a sample provider based on configured components
    /// </summary>
    public interface ISampleProviderFactory
    {
        Oscillator Oscillator { get; set; }
        Oscillator Lfo { get; set; }
        Filter Filter { get; set; }
        Adsr Adsr { get; set; }
        float Volume { get; set; }

        ISampleProvider BuildSampleProvider();
    }
}
