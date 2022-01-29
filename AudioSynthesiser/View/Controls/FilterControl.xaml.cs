using AudioSynthesiser.Model;
using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for FilterControl.xaml
    /// </summary>
    public partial class FilterControl : UserControl
    {
        public bool Enabled
        {
            get => (bool)GetValue(EnabledProperty);
            set => SetValue(EnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(FilterControl), new PropertyMetadata(false));

        public FilterType Type
        {
            get => (FilterType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(FilterType), typeof(FilterControl), new PropertyMetadata(FilterType.LowPass));

        public float CutoffFreq
        {
            get { return (float)GetValue(CutoffFreqProperty); }
            set { SetValue(CutoffFreqProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cutoffFreq.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CutoffFreqProperty =
            DependencyProperty.Register("CutoffFreq", typeof(float), typeof(FilterControl), new PropertyMetadata(0f));

        public float QValue
        {
            get { return (float)GetValue(QValueProperty); }
            set { SetValue(QValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for QValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty QValueProperty =
            DependencyProperty.Register("QValue", typeof(float), typeof(FilterControl), new PropertyMetadata(0f));

        public FilterControl()
        {
            InitializeComponent();
        }
    }
}
