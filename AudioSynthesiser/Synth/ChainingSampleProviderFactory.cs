using AudioSynthesiser.Model;
using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioSynthesiser.Synth
{
    public class ChainingSampleProviderFactory : ISampleProviderFactory
    {
        public Oscillator Oscillator { get; set; }
        public Oscillator Lfo { get; set; }
        public Filter Filter { get; set; }
        public float Volume { get; set; } = 1.0f;

        public ISampleProvider Make()
        {
            ISampleProvider result;

            if (Oscillator == null || !Oscillator.IsEnabled())
            {
                return null;
            }

            result = new SignalGenerator()
            {
                Gain = Oscillator.Gain,
                Frequency = Oscillator.Frequency,
                Type = Oscillator.Type
            };

            if (Lfo != null && Lfo.IsEnabled())
            {
                ISampleProvider lfoProvider = new SignalGenerator()
                {
                    Gain = Lfo.Gain,
                    Frequency = Lfo.Frequency,
                    Type = Lfo.Type
                };

                result = new LfoProvider(result, lfoProvider);
            }

            if (Filter != null && Filter.IsEnabled())
            {
                var filter = new SynthFilter(Filter, result);
                result = new FilterProvider(result, filter);
            }

            result = new VolumeSampleProvider(result)
            {
                Volume = Volume
            };

            return result;
        }

    }
}
