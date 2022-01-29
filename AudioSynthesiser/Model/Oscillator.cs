using NAudio.Wave.SampleProviders;
using System.ComponentModel;

namespace AudioSynthesiser.Model
{
    public class Oscillator
    {
        private double frequency;
        private double gain;
        private SignalGeneratorType type;
        public Oscillator(SignalGeneratorType type, double frequency, double gain)
        {
            this.frequency = frequency;
            this.gain = gain;
            this.type = type;
        }

        public double Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
                //OnPropertyChanged("Frequency");
            }
        }

        public double Gain
        {
            get => gain;
            set
            {
                gain = value;
                //OnPropertyChanged("Gain");
            }
        }

        public SignalGeneratorType Type
        {
            get => type;
            set
            {
                type = value;
                //OnPropertyChanged("Type");
            }
        }
    }
}
