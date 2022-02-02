using AudioSynthesiser.Model;
using AudioSynthesiser.Synth;
using AudioSynthesiser.Synth.SampleProviders;
using AudioSynthesiser.ViewModel.Commands;
using NAudio.Wave.SampleProviders;
using System.ComponentModel;

namespace AudioSynthesiser.ViewModel
{
    public class SynthesiserViewModel : INotifyPropertyChanged
    {
        #region props

        private readonly ISampleProviderFactory _synthFactory;
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

        // ADSR Envelope

        private bool adsrOn;
        public bool AdsrOn
        {
            get => adsrOn;
            set
            {
                adsrOn = value;
                OnPropertyChanged("AdsrOn");
                UpdateLfo();
            }
        }

        private float attack;
        public float Attack
        {
            get => attack;
            set {
                attack = value;
                OnPropertyChanged("Attack");
                UpdateAdsr();
            }
        }

        private float decay;
        public float Decay
        {
            get => decay;
            set
            {
                decay = value;
                OnPropertyChanged("Decay");
                UpdateAdsr();
            }
        }

        private int sustain;
        public int Sustain
        {
            get => sustain;
            set
            {
                sustain = value;
                OnPropertyChanged("Sustain");
                UpdateAdsr();
            }
        }

        private float release;
        public float Release
        {
            get => release;
            set
            {
                release = value;
                OnPropertyChanged("Release");
                UpdateAdsr();
            }
        }

        #endregion

        public SynthPlayCommand PlayCommand { get; set; }
        public SynthStopCommand StopCommand { get; set; }

        public SynthesiserViewModel(ISynthesiser synthesiser, ISampleProviderFactory synthesiserFactory)
        {
            Synthesiser = synthesiser;
            _synthFactory = synthesiserFactory;

            PlayCommand = new SynthPlayCommand(this);
            StopCommand = new SynthStopCommand(this);

            SetDefaults();
        }
        public SynthesiserViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateOscillator()
        {
            _synthFactory.Oscillator = new Oscillator(waveForm, baseFreq, gain, oscOn);
            UpdateSynth();
        }
        private void UpdateLfo()
        {
            _synthFactory.Lfo = new Oscillator(lfoWaveForm, lfoFreq, lfoAmplitude, lfoOn);
            UpdateSynth();
        }

        private void UpdateFilter()
        {
            _synthFactory.Filter = new Filter(filterType, filterFreq, filterQ, filterOn);
            UpdateSynth();
        }

        private void UpdateAdsr()
        {
            _synthFactory.Adsr = new Adsr(attack, decay, sustain, release, adsrOn);
            UpdateSynth();
        }

        private void UpdateVolume()
        {
            _synthFactory.Volume = Volume;
            UpdateSynth();
        }

        private void UpdateSynth()
        {
            Synthesiser.SetSampleProvider(_synthFactory.BuildSampleProvider());
            Synthesiser.Update();
        }
        private void SetDefaults()
        {
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

            AdsrOn = false;
            Attack = 1;
            Decay = 1;
            Sustain = 50;
            Release = 1;

            Volume = 1;
        }


    }
}
