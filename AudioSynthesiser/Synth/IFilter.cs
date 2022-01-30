namespace AudioSynthesiser.Synth
{
    public interface IFilter
    {
        public float Transform(float inSample);
    }
}
