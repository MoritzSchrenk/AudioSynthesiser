using AudioSynthesiser.Model;
using NAudio.Dsp;
using NAudio.Wave;

namespace AudioSynthesiser.Synth.SampleProviders
{
    /// <summary>
    /// Wraps a sample provider in an ADSR envelope
    /// </summary>
    public class AdsrEnvelopeProvider : AbstractSampleProviderDecorator
    {
        private readonly EnvelopeGenerator _envelope;

        public AdsrEnvelopeProvider(ISampleProvider sourceProvider, Adsr adsr) : base(sourceProvider)
        {
            PlaybackMediator.StartPlaying += Start;
            PlaybackMediator.StopPlaying += Stop;

            _envelope = new EnvelopeGenerator();
            _envelope.AttackRate = adsr.Attack * WaveFormat.SampleRate;
            _envelope.DecayRate = adsr.Decay * WaveFormat.SampleRate;
            _envelope.SustainLevel = adsr.Sustain / 100.0f;
            _envelope.ReleaseRate = adsr.Release * WaveFormat.SampleRate;
        }

        public override int Read(float[] buffer, int offset, int count)
        {
            if (_envelope.State == EnvelopeGenerator.EnvelopeState.Idle)
            {
                //No sound
                return 0;
            }

            var samples = SourceProvider.Read(buffer, offset, count);
            for (int n = 0; n < samples; n++)
            {
                buffer[offset++] *= _envelope.Process();
            }
            return samples;
        }

        public void Stop()
        {
            _envelope.Gate(false);
        }

        public void Start()
        {
            _envelope.Gate(true);
        }
    }
}