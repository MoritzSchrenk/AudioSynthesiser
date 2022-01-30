using AudioSynthesiser.Model;

namespace AudioSynthesiser.Synth
{
    public interface ISynthesiser
    {
        Oscillator Oscillator { set; }
        Oscillator Lfo { set; }
        Filter Filter { set; }
        float Volume { set; }

        void Play();
        void Update();
        void Stop();
    }
}
