using NAudio.Wave.SampleProviders;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for OscillatorControl.xaml
    /// </summary>
    public partial class OscillatorControl : UserControl
    {
        public OscillatorControl()
        {
            InitializeComponent();
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(OscillatorControl), new PropertyMetadata(""));

        public SignalGeneratorType WaveForm
        {
            get => (SignalGeneratorType)GetValue(WaveFormProperty);
            set => SetValue(WaveFormProperty, value);
        }

        // Using a DependencyProperty as the backing store for WaveForm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaveFormProperty =
            DependencyProperty.Register("WaveForm", typeof(SignalGeneratorType), typeof(OscillatorControl), new PropertyMetadata(SignalGeneratorType.Sin));

        public double OscFreq
        {
            get => (double)GetValue(OscFreqProperty);
            set => SetValue(OscFreqProperty, value);
        }

        // Using a DependencyProperty as the backing store for BaseFreq.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OscFreqProperty =
            DependencyProperty.Register("OscFreq", typeof(double), typeof(OscillatorControl), new PropertyMetadata(0d));

        public double Amplitude
        {
            get => (double)GetValue(AmplitudeProperty);
            set => SetValue(AmplitudeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Amplitude.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AmplitudeProperty =
            DependencyProperty.Register("Amplitude", typeof(double), typeof(OscillatorControl), new PropertyMetadata(0d));
    }
}
