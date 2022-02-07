namespace AudioSynthesiser.Synth
{
    /// <summary>
    /// Filters an incoming sample
    /// </summary>
    public interface IFilter
    {
        public float Transform(float inSample);
    }
}
