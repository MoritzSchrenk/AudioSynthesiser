using System;

namespace AudioSynthesiser.Model
{
    public class Adsr : SynthComponent
    {
        /// <summary>
        /// Attack (in seconds)
        /// </summary>
        public float Attack { get; set; }

        /// <summary>
        /// Decay (in seconds)
        /// </summary>
        public float Decay { get; set; }
        /// <summary>
        /// Sustain (as percentage)
        /// </summary>
        public int Sustain { get; set; }
        /// <summary>
        /// Release (in seconds)
        /// </summary>
        public float Release { get; set; }

        public Adsr(float attack, float decay, int sustain, float release, bool isEnabled = false) : base(isEnabled)
        {
            if(!(sustain >= 0 && sustain <= 100))
            {
                throw new ArgumentException("Sustain must be expressed as a percentage between 0 and 100");
            }
            Attack = attack;
            Decay = decay;
            Sustain = sustain;
            Release = release;
        }

        public static Adsr NoEnvelope()
        {
            return new Adsr(0, 0, 100, 0);
        }
    }
}
