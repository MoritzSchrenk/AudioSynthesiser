using AudioSynthesiser.Model;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

namespace AudioSynthesiser.Synth.SampleProviders
{
    public class ChainingSampleProviderBuilder : ISampleProviderBuilder
    {
        private ISampleProvider sampleProvider;

        public ISampleProvider GetSampleProvider()
        {
            if (sampleProvider == null)
            {
                return null;
            }

            return sampleProvider;
        }

        public ISampleProviderBuilder WithSignalGenerator(Oscillator oscillator)
        {
            if (oscillator != null && oscillator.IsEnabled())
            {
                sampleProvider = new SignalGenerator()
                {
                    Gain = oscillator.Gain,
                    Frequency = oscillator.Frequency,
                    Type = oscillator.Type
                };
            }
            return this;
        }

        public ISampleProviderBuilder WithLfo(Oscillator lfo)
        {
            if (lfo != null && lfo.IsEnabled())
            {
                if (sampleProvider is null)
                {
                    throw new NotSupportedException("Lfo requires a signal generator to be set");
                }

                var lfoGenerator = new SignalGenerator()
                {
                    Gain = lfo.Gain,
                    Frequency = lfo.Frequency,
                    Type = lfo.Type
                };

                sampleProvider = new LfoProvider(sampleProvider, lfoGenerator);
            }
            return this;
        }

        public ISampleProviderBuilder WithFilter(Filter filter)
        {
            if (filter != null && filter.IsEnabled())
            {
                if (sampleProvider is null)
                {
                    throw new NotSupportedException("Filter requires a signal generator to be set");
                }

                var filterGenerator = new SynthFilter(filter, sampleProvider);
                sampleProvider = new FilterProvider(sampleProvider, filterGenerator);
            }
            return this;
        }

        public ISampleProviderBuilder WithVolume(float volume)
        {
            if (sampleProvider is null)
            {
                throw new NotSupportedException("Volume requires a signal generator to be set");
            }

            sampleProvider = new VolumeSampleProvider(sampleProvider)
            {
                Volume = volume
            };
            return this;
        }
    }
}
