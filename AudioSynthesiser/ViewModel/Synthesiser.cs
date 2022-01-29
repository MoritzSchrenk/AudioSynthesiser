﻿using AudioSynthesiser.Model;
using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioSynthesiser.ViewModel
{
    public class Synthesiser
    {
        public Oscillator Oscillator { get; set; }
        public Filter Filter { get; set; }

        private WaveOutEvent wo;
        public void Play()
        {
            ISampleProvider  sg = new SignalGenerator()
            {
                Gain = Oscillator.Gain,
                Frequency = Oscillator.Frequency,
                Type = Oscillator.Type
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
                case FilterType.Off:
                default:
                    break;
            }

            if (filter != null)
            {
                var filteredsg = new FilterProvider(sg, filter);
                sg = filteredsg;
            }

            if (wo == null)
            {
                wo = new WaveOutEvent();
            }
            wo.Init(sg);
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
