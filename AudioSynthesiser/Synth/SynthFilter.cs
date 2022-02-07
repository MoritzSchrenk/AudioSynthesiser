using AudioSynthesiser.Model;
using NAudio.Dsp;
using NAudio.Wave;

namespace AudioSynthesiser.Synth
{
    /// <summary>
    /// a BiQuad filter
    /// </summary>
    public class SynthFilter : IFilter
    {
        private readonly BiQuadFilter _filter;

        public SynthFilter(Filter filter, ISampleProvider sourceSample)
        {
            switch (filter.Type)
            {
                case FilterType.LowPass:
                    _filter = BiQuadFilter.LowPassFilter(sourceSample.WaveFormat.SampleRate, filter.Frequency, filter.Q);
                    break;
                case FilterType.HighPass:
                    _filter = BiQuadFilter.HighPassFilter(sourceSample.WaveFormat.SampleRate, filter.Frequency, filter.Q);
                    break;
                case FilterType.BandPass:
                    _filter = BiQuadFilter.BandPassFilterConstantPeakGain(sourceSample.WaveFormat.SampleRate, filter.Frequency, filter.Q);
                    break;
                case FilterType.Notch:
                    _filter = BiQuadFilter.NotchFilter(sourceSample.WaveFormat.SampleRate, filter.Frequency, filter.Q);
                    break;
            }
        }

        public float Transform(float inSample)
        {
            return _filter.Transform(inSample);
        }
    }
}
