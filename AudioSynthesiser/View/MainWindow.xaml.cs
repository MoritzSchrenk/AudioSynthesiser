using AudioSynthesiser.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NAudio.Wave.SampleProviders;
using System.Text.RegularExpressions;
using AudioSynthesiser.ViewModel;

namespace AudioSynthesiser.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Synthesiser Synth = new Synthesiser();

        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Window_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Synth.Play();
        //}

        //private void WaveformRadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    //var button = (RadioButton)sender;
        //    //if (button == SineWave)
        //    //{
        //    //    Synth.WaveForm = SignalGeneratorType.Sin;
        //    //}
        //    //else if (button == SawtoothWave)
        //    //{
        //    //    Synth.WaveForm = SignalGeneratorType.SawTooth;
        //    //}
        //    //else if (button == TriangleWave)
        //    //{
        //    //    Synth.WaveForm = SignalGeneratorType.Triangle;
        //    //}
        //    //else if (button == SquareWave)
        //    //{
        //    //    Synth.WaveForm = SignalGeneratorType.Square;
        //    //}
        //    //Synth.Update();
        //}

        //private void FrequencyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var textBox = (TextBox)sender;
        //    if (!int.TryParse(textBox.Text, out int value))
        //    {
        //        value = 500;
        //    }
        //    Synth.Frequency = value;
        //    Synth.Update();
        //}

        //private void NumericalTextBox_PreviewInput(object sender, TextCompositionEventArgs e)
        //{
        //    var reg = new Regex("[^0-9]");
        //    e.Handled = reg.IsMatch(e.Text);
        //}

        //private void FilterRadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    //var button = (RadioButton)sender;
        //    //if (button == NoFilter)
        //    //{
        //    //    Synth.Filter.Type = FilterType.Off;
        //    //}
        //    //else if (button == LowPassFilter)
        //    //{
        //    //    Synth.Filter.Type = FilterType.LowPass;
        //    //}
        //    //else if (button == HighPassFilter)
        //    //{
        //    //    Synth.Filter.Type = FilterType.HighPass;
        //    //}
        //    //else if (button == BandPassFilter)
        //    //{
        //    //    Synth.Filter.Type = FilterType.BandPass;
        //    //}
        //    //else if (button == NotchFilter)
        //    //{
        //    //    Synth.Filter.Type = FilterType.Notch;
        //    //}
        //    //Synth.Update();
        //}

        //private void FilterqTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var textBox = (TextBox)sender;
        //    if (!int.TryParse(textBox.Text, out int value))
        //    {
        //        value = 1;
        //    }
        //    Synth.Filter.Q = value;
        //    Synth.Update();
        //}

        //private void FilterFreqTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var textBox = (TextBox)sender;
        //    if (!int.TryParse(textBox.Text, out int value))
        //    {
        //        value = 500;
        //    }
        //    Synth.Filter.Frequency = value;
        //    Synth.Update();
        //}
    }
}
