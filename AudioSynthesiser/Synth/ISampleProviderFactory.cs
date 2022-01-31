using NAudio.Wave;

namespace AudioSynthesiser.Synth
{
    public interface ISampleProviderFactory
    {
        ISampleProvider Make();
    }
}
