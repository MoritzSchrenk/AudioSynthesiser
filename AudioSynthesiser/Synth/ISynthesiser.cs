using NAudio.Wave;

namespace AudioSynthesiser.Synth
{
    /// <summary>
    /// Plays the sound from a sample provider
    /// </summary>
    public interface ISynthesiser
    {
        void SetSampleProvider(ISampleProvider sampleProvider);
        void Play();
        void Update();
        void Stop();
    }
}
