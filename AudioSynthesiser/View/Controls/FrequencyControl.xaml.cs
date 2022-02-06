using System;
using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for FrequencyControl.xaml
    /// </summary>
    public partial class FrequencyControl : UserControl
    {
        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(FrequencyControl), new PropertyMetadata(1));

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(FrequencyControl), new PropertyMetadata(1));

        public bool Enabled
        {
            get => (bool)GetValue(EnabledProperty);
            set => SetValue(EnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(FrequencyControl), new PropertyMetadata(false));

        public double Frequency
        {
            get => (double)GetValue(FrequencyProperty);
            set => SetValue(FrequencyProperty, value);
        }

        // Using a DependencyProperty as the backing store for frequency.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrequencyProperty =
            DependencyProperty.Register("Frequency", typeof(double), typeof(FrequencyControl), new PropertyMetadata(0d, FrequencyChanged));


        private static void FrequencyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrequencyControl control)
            {
                if ((double)e.NewValue >= control.MaxValue)
                {
                    control.Frequency = control.MaxValue;
                }
                else if ((double)e.NewValue <= control.MinValue)
                {
                    control.Frequency = control.MinValue;
                }
            }
        }


        public FrequencyControl()
        {
            InitializeComponent();
        }

    }
}
