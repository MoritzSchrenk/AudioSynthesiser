using AudioSynthesiser.Synth;
using System;

namespace AudioSynthesiserTests
{
    public class DummyFilter : IFilter
    {
        private readonly Func<float, float> _transformation;

        public DummyFilter(Func<float, float> Transformation)
        {
            _transformation = Transformation;
        }
        public float Transform(float inSample)
        {
            return _transformation(inSample);
        }
    }
}
