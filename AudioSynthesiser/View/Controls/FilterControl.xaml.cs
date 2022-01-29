using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for FilterControl.xaml
    /// </summary>
    public partial class FilterControl : UserControl
    {
        public FilterControl()
        {
            InitializeComponent();
        }

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
    }
}
