using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for VerticalSliderControl.xaml
    /// </summary>
    public partial class SustainControl : UserControl
    {
        public bool Enabled
        {
            get => (bool)GetValue(EnabledProperty);
            set => SetValue(EnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(SustainControl), new PropertyMetadata(false));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(SustainControl), new PropertyMetadata(""));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(SustainControl), new PropertyMetadata(100, ValueChanged));

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is VerticalSliderControl control)
            {
                if ((int)e.NewValue >= control.MaxValue)
                {
                    control.Value = control.MaxValue;
                }
                else if ((int)e.NewValue <= control.MinValue)
                {
                    control.Value = control.MinValue;
                }
            }
        }

        public int MinValue
        {
            get { return (int)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(SustainControl), new PropertyMetadata(0));

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(SustainControl), new PropertyMetadata(100));



        public SustainControl()
        {
            InitializeComponent();
        }
    }
}
