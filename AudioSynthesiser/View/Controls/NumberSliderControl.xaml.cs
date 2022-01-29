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
    /// Interaction logic for NumberSliderControl.xaml
    /// </summary>
    public partial class NumberSliderControl : UserControl
    {
        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(float), typeof(NumberSliderControl), new PropertyMetadata(1f, SetValue));

        private static void SetValue(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumberSliderControl control)
            {
                control.NumberTextBox.Text = Convert.ToSingle(e.NewValue).ToString();
                control.Slider.Value = Convert.ToDouble(e.NewValue);
            }
        }

        public NumberSliderControl()
        {
            InitializeComponent();
        }
    }
}
