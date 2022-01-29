using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for FrequencyControl.xaml
    /// </summary>
    public partial class FrequencyControl : UserControl
    {
        public FrequencyControl()
        {
            InitializeComponent();
        }

        public double Frequency
        {
            get => (double)GetValue(FrequencyProperty);
            set => SetValue(FrequencyProperty, value);
        }

        // Using a DependencyProperty as the backing store for frequency.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrequencyProperty =
            DependencyProperty.Register("Frequency", typeof(double), typeof(FrequencyControl), new PropertyMetadata(0d));
    }
}
