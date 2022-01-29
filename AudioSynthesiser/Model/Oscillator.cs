using NAudio.Wave.SampleProviders;

namespace AudioSynthesiser.Model
{
    public class Oscillator : SynthComponent
    {
        public double Frequency { get; }
        public double Gain { get; }
        public SignalGeneratorType Type { get; }

        public Oscillator(SignalGeneratorType type, double frequency, double gain, bool enabled = false) : base(enabled)
        {
            Frequency = frequency;
            Gain = gain;
            Type = type;
        }
    }
}