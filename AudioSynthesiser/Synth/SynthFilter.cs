using NAudio.Dsp;

namespace AudioSynthesiser.Synth
{
    public class SynthFilter : IFilter
    {
        private readonly BiQuadFilter _filter;

        public SynthFilter(BiQuadFilter filter)
        {
            _filter = filter;
        }

        public float Transform(float inSample)
        {
            return _filter.Transform(inSample);
        }
    }
}
