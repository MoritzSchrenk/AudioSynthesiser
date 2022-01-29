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

        public double OscFreq
        {
            get => (double)GetValue(OscFreqProperty);
            set => SetValue(OscFreqProperty, value);
        }

        // Using a DependencyProperty as the backing store for BaseFreq.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OscFreqProperty =
            DependencyProperty.Register("OscFreq", typeof(double), typeof(OscillatorControl), new PropertyMetadata(0d));
    }
}
