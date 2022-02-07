using NAudio.Wave.SampleProviders;

namespace AudioSynthesiser.Model
{
    public class Oscillator : SynthComponent
    {
        /// <summary>
        /// The oscillation frequency
        /// </summary>
        public double Frequency { get; }
        /// <summary>
        /// The amplitude of the generated signal
        /// </summary>
        public double Gain { get; }
        /// <summary>
        /// The type/shape of the generated signal
        /// </summary>
        public SignalGeneratorType Type { get; }

        public Oscillator(SignalGeneratorType type, double frequency, double gain, bool enabled = false) : base(enabled)
        {
            Frequency = frequency;
            Gain = gain;
            Type = type;
        }
    }
}