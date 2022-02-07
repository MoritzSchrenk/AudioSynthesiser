using AudioSynthesiser.Model;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;

namespace AudioSynthesiser.Synth.SampleProviders
{
    /// <summary>
    /// Chains components together into a sample provider
    /// </summary>
    public class ChainingSampleProviderBuilder : ISampleProviderBuilder
    {
        private ISampleProvider _sampleProvider;

        public ISampleProvider GetSampleProvider()
        {
            if (_sampleProvider == null)
            {
                return null;
            }

            return _sampleProvider;
        }

        public ISampleProviderBuilder WithSignalGenerator(Oscillator oscillator)
        {
            if (oscillator != null && oscillator.IsEnabled())
            {
                _sampleProvider = new SignalGenerator()
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
                if (_sampleProvider is null)
                {
                    throw new NotSupportedException("Lfo requires a signal generator to be set");
                }

                var lfoGenerator = new SignalGenerator()
                {
                    Gain = lfo.Gain,
                    Frequency = lfo.Frequency,
                    Type = lfo.Type
                };

                _sampleProvider = new LfoProvider(_sampleProvider, lfoGenerator);
            }
            return this;
        }

        public ISampleProviderBuilder WithFilter(Filter filter)
        {
            if (filter != null && filter.IsEnabled())
            {
                if (_sampleProvider is null)
                {
                    throw new NotSupportedException("Filter requires a signal generator to be set");
                }

                var filterGenerator = new SynthFilter(filter, _sampleProvider);
                _sampleProvider = new FilterProvider(_sampleProvider, filterGenerator);
            }
            return this;
        }

        public ISampleProviderBuilder WithEnvelope(Adsr adsr)
        {
            if(adsr == null || !adsr.IsEnabled())
            {
                adsr = Adsr.NoEnvelope();
            }

            if (_sampleProvider is null)
            {
                throw new NotSupportedException("ADSR Envelope requires a signal generator to be set");
            }

            _sampleProvider = new AdsrEnvelopeProvider(_sampleProvider, adsr);

            return this;
        }

        public ISampleProviderBuilder WithVolume(float volume)
        {
            if (_sampleProvider is null)
            {
                throw new NotSupportedException("Volume requires a signal generator to be set");
            }

            _sampleProvider = new VolumeSampleProvider(_sampleProvider)
            {
                Volume = volume
            };
            return this;
        }
    }
}
