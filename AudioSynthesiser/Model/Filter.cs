namespace AudioSynthesiser.Model
{
    public class Filter : SynthComponent
    {
        /// <summary>
        /// The filter typ[e
        /// </summary>
        public FilterType Type { get; }
        /// <summary>
        /// The filter's cutoff frequency
        /// </summary>
        public float Frequency { get; }
        /// <summary>
        /// The filter's Q Value
        /// </summary>
        public float Q { get; }

        public Filter(FilterType type, float frequency, float q, bool enabled = false) : base(enabled)
        {
            Type = type;
            Frequency = frequency;
            Q = q;
        }
    }
}
