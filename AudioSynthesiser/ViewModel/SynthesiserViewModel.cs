using AudioSynthesiser.Model;
using AudioSynthesiser.Synth;
using AudioSynthesiser.ViewModel.Commands;
using NAudio.Wave.SampleProviders;
using System.ComponentModel;

namespace AudioSynthesiser.ViewModel
{
    public class SynthesiserViewModel : INotifyPropertyChanged
    {
        #region props

        public ISynthesiser Synthesiser { get; set; }

        private float volume;
        public float Volume
        {
            get => volume;
            set
            {
                volume = value;
                OnPropertyChanged("Volume");
                UpdateVolume();
            }
        }


        // Oscillator
        private bool oscOn;
        public bool OscOn
        {
            get => oscOn;
            set
            {
                oscOn = value;
                OnPropertyChanged("OscOn");
                UpdateOscillator();
            }
        }

        private double baseFreq;
        public double BaseFreq
        {
            get => baseFreq;
            set
            {
                baseFreq = value;
                OnPropertyChanged("BaseFreq");
                UpdateOscillator();
            }
        }

        private double gain;
        public double Gain
        {
            get => gain;
            set
            {
                gain = value;
                OnPropertyChanged("Gain");
                UpdateOscillator();
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
                UpdateOscillator();
            }
        }

        // Filter
        private bool filterOn;
        public bool FilterOn
        {
            get => filterOn;
            set
            {
                filterOn = value;
                OnPropertyChanged("FilterOn");
                UpdateFilter();
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
                UpdateFilter();
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
                UpdateFilter();
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
                UpdateFilter();
            }
        }

        // LFO
        private bool lfoOn;
        public bool LfoOn
        {
            get => lfoOn;
            set
            {
                lfoOn = value;
                OnPropertyChanged("LfoOn");
                UpdateLfo();
            }
        }

        private double lfoFreq;
        public double LfoFreq
        {
            get => lfoFreq;
            set
            {
                lfoFreq = value;
                OnPropertyChanged("LfoFreq");
                UpdateLfo();
            }
        }

        private double lfoAmplitude;
        public double LfoAmplitude
        {
            get => lfoAmplitude;
            set
            {
                lfoAmplitude = value;
                OnPropertyChanged("LfoAmplitude");
                UpdateLfo();
            }
        }

        private SignalGeneratorType lfoWaveForm;
        public SignalGeneratorType LfoWaveForm
        {
            get => lfoWaveForm;
            set
            {
                lfoWaveForm = value;
                OnPropertyChanged("LfoWaveForm");
                UpdateLfo();
            }
        }

        #endregion

        public SynthPlayCommand PlayCommand { get; set; }
        public SynthStopCommand StopCommand { get; set; }

        public SynthesiserViewModel(ISynthesiser synthesiser)
        {
            Synthesiser = synthesiser;

            PlayCommand = new SynthPlayCommand(this);
            StopCommand = new SynthStopCommand(this);

            Volume = 1;

            OscOn = true;
            WaveForm = SignalGeneratorType.Sin;
            BaseFreq = 500;
            Gain = 0.05;

            FilterOn = false;
            FilterType = FilterType.LowPass;
            FilterFreq = 250;
            FilterQ = 1;

            LfoOn = false;
            LfoWaveForm = SignalGeneratorType.Sin;
            LfoFreq = 5;
            LfoAmplitude = 0.25;

            UpdateOscillator();
            UpdateFilter();
            UpdateLfo();
        }

        public SynthesiserViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateVolume()
        {
            Synthesiser.Volume = Volume;
            Synthesiser.Update();
        }

        private void UpdateOscillator()
        {
            Synthesiser.Oscillator = new Oscillator(waveForm, baseFreq, gain, oscOn);
            Synthesiser.Update();
        }
        private void UpdateFilter()
        {
            Synthesiser.Filter = new Filter(filterType, filterFreq, filterQ, filterOn);
            Synthesiser.Update();
        }
        private void UpdateLfo()
        {
            Synthesiser.Lfo = new Oscillator(lfoWaveForm, lfoFreq, lfoAmplitude, lfoOn);
            Synthesiser.Update();
        }
    }
}
