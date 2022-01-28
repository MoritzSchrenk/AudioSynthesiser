using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for FrequencyControl.xaml
    /// </summary>
    public partial class FrequencyControl : UserControl
    {
        public int Frequency
        {
            get { return (int)GetValue(FrequencyProperty); }
            set { SetValue(FrequencyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for frequency.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrequencyProperty =
            DependencyProperty.Register("Frequency", typeof(int), typeof(FrequencyControl), new PropertyMetadata(500, SetFreq));

        private static void SetFreq(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrequencyControl control = d as FrequencyControl;
            if(control != null)
            {
                control.FreqTextBox.Text = e.NewValue.ToString();
                control.FreqSlider.Value = (int)e.NewValue;
            }
        }

        public FrequencyControl()
        {
            InitializeComponent();
        }
    }
}
