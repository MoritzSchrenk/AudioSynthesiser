using AudioSynthesiser.Model;
using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioSynthesiser.Synth
{
    public class Synthesiser : ISynthesiser
    {
        public Oscillator Oscillator { get; set; }
        public Oscillator Lfo { get; set; }
        public Filter Filter { get; set; }
        public float Volume { get; set; }


        private WaveOutEvent wo;
        public void Play()
        {
            if (!Oscillator.IsEnabled())
            {
                Stop();
                return;
            }

            ISampleProvider sg = new SignalGenerator()
            {
                Gain = Oscillator.Gain,
                Frequency = Oscillator.Frequency,
                Type = Oscillator.Type
            };

            if (Lfo.IsEnabled())
            {
                ISampleProvider lfoProvider = new SignalGenerator()
                {
                    Gain = Lfo.Gain,
                    Frequency = Lfo.Frequency,
                    Type = Lfo.Type
                };

                sg = new LfoProvider(sg, lfoProvider);
            }

            if (Filter.IsEnabled())
            {
                BiQuadFilter filter = null;
                switch (Filter.Type)
                {
                    case FilterType.LowPass:
                        filter = BiQuadFilter.LowPassFilter(sg.WaveFormat.SampleRate, Filter.Frequency, Filter.Q);
                        break;
                    case FilterType.HighPass:
                        filter = BiQuadFilter.HighPassFilter(sg.WaveFormat.SampleRate, Filter.Frequency, Filter.Q);
                        break;
                    case FilterType.BandPass:
                        filter = BiQuadFilter.BandPassFilterConstantPeakGain(sg.WaveFormat.SampleRate, Filter.Frequency, Filter.Q);
                        break;
                    case FilterType.Notch:
                        filter = BiQuadFilter.NotchFilter(sg.WaveFormat.SampleRate, Filter.Frequency, Filter.Q);
                        break;
                }
                sg = new FilterProvider(sg, filter);
            }

            if (wo == null)
            {
                wo = new WaveOutEvent();
            }
            else
            {
                wo.Stop();
            }

            wo.Init(sg);
            wo.Volume = Volume;
            wo.Play();
        }

        public void Update()
        {
            if (wo != null)
            {
                Play();
            }
        }

        public void Stop()
        {
            if (wo != null)
            {
                wo.Stop();
                wo = null;
            }
        }
    }
}
