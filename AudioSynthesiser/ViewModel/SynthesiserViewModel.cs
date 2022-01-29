using AudioSynthesiser.Model;
using NAudio.Wave.SampleProviders;
using System.ComponentModel;

namespace AudioSynthesiser.ViewModel
{
    public class SynthesiserViewModel : INotifyPropertyChanged
    {
        #region props

        public Synthesiser Synth { get; set; }


        private double baseFreq;
        public double BaseFreq
        {
            get => baseFreq;
            set
            {
                baseFreq = value;
                OnPropertyChanged("BaseFreq");
                UpdateSynth();
            }
        }

        private double gain;
        public double Gain
        {
            get => gain;
            set
            {
                gain = value;
                OnPropertyChanged("Gain");UpdateSynth();
                UpdateSynth();
            }
        }

        private SignalGeneratorType waveForm;
        public SignalGeneratorType WaveForm
        {
            get => waveForm;
            set
            {
                waveForm = value;
                OnPropertyChanged("WaveForm");
                UpdateSynth();
            }
        }

        private float filterFreq;
        public float FilterFreq
        {
            get => filterFreq;
            set
            {
                filterFreq = value;
                OnPropertyChanged("FilterFreq");
                UpdateSynth();
            }
        }

        private float filterQ;
        public float FilterQ
        {
            get => filterQ;
            set
            {
                filterQ = value;
                OnPropertyChanged("FilterQ");
                UpdateSynth();
            }
        }

        private FilterType filterType;
        public FilterType FilterType
        {
            get => filterType;
            set
            {
                filterType = value;
                OnPropertyChanged("FilterType");
                UpdateSynth();
            }
        }

        #endregion


        public SynthPlayCommand PlayCommand { get; set; }
        public SynthStopCommand StopCommand { get; set; }

        public SynthesiserViewModel()
        {
            PlayCommand = new SynthPlayCommand(this);
            StopCommand = new SynthStopCommand(this);

            Synth = new Synthesiser();

            WaveForm = SignalGeneratorType.Sin;
            BaseFreq = 5000;
            Gain = 0.05;
            FilterType = FilterType.LowPass;
            FilterFreq = 350;
            FilterQ = 2;

            UpdateSynth();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateSynth()
        {
            Synth.Oscillator = new Oscillator(waveForm, baseFreq, gain);
            Synth.Filter = new Filter(filterType, filterFreq, filterQ);
            Synth.Update();
        }
    }
}
