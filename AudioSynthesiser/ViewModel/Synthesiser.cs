using AudioSynthesiser.Model;
using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioSynthesiser.ViewModel
{
    internal class Synthesiser
    {
        public SignalGeneratorType WaveForm {get; set;}
        public int Frequency { get; set; }
        public Filter Filter { get; set; } = new Filter(FilterType.Off, 0, 0);

        WaveOutEvent wo;
        public void Play()
        {
            if (wo != null)
            {
                wo.Stop();
                wo = null;
            }

            ISampleProvider  sg = new SignalGenerator()
            {
                Gain = 0.05,
                Frequency = Frequency,
                Type = WaveForm
            };

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
                default:
                    break;
            }

            if (filter != null)
            {
                var filteredsg = new FilterProvider(sg, filter);
                sg = filteredsg;
            }

            var waveProvider = new SampleToWaveProvider(sg);


            //var renderer = new WaveFormRenderer();

            //renderer.Render(waveProvider, null);

            wo = new WaveOutEvent();
            wo.Init(waveProvider);
            wo.Play();
        }

        public void Update()
        {
            if(wo != null)
            {
                Play();
            }
        }
    }
}
