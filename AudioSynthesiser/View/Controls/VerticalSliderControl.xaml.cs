using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for VerticalSliderControl.xaml
    /// </summary>
    public partial class VerticalSliderControl : UserControl
    {
        public bool Enabled
        {
            get => (bool)GetValue(EnabledProperty);
            set => SetValue(EnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(VerticalSliderControl), new PropertyMetadata(false));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(VerticalSliderControl), new PropertyMetadata(""));

        public float Value
        {
            get => (float)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(float), typeof(VerticalSliderControl), new PropertyMetadata(0.3f, ValueChanged));

        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is VerticalSliderControl control)
            {
                if ((float)e.NewValue >= control.MaxValue)
                {
                    control.Value = control.MaxValue;
                }
                else if ((float)e.NewValue <= control.MinValue)
                {
                    control.Value = control.MinValue;
                }
            }
        }

        public float MinValue
        {
            get { return (float)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(float), typeof(VerticalSliderControl), new PropertyMetadata(0f));

        public float MaxValue
        {
            get { return (float)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(float), typeof(VerticalSliderControl), new PropertyMetadata(5f));

        public VerticalSliderControl()
        {
            InitializeComponent();
        }
    }
}
