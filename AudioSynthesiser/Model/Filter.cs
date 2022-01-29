namespace AudioSynthesiser.Model
{
    public class Filter : SynthComponent
    {
        public FilterType Type { get; }
        public float Frequency { get; }
        public float Q { get; }

        public Filter(FilterType type, float frequency, float q, bool enabled = false) : base(enabled)
        {
            Type = type;
            Frequency = frequency;
            Q = q;
        }
    }
}
