using NAudio.Wave;

namespace AudioSynthesiser.Synth
{
    public interface ISynthesiser
    {
        void SetSampleProvider(ISampleProvider sampleProvider);
        void Play();
        void Update();
        void Stop();
    }
}
