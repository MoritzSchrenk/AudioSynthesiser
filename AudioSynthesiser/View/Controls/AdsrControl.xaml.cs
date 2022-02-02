using System;
using System.Windows;
using System.Windows.Controls;

namespace AudioSynthesiser.View.Controls
{
    /// <summary>
    /// Interaction logic for AdsrControl.xaml
    /// </summary>
    public partial class AdsrControl : UserControl
    {
        public bool Enabled
        {
            get => (bool)GetValue(EnabledProperty);
            set => SetValue(EnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for Enabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(AdsrControl), new PropertyMetadata(false));

        public float Attack
        {
            get => (float)GetValue(AttackProperty);
            set => SetValue(AttackProperty, value);
        }

        // Using a DependencyProperty as the backing store for Attack.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttackProperty =
            DependencyProperty.Register("Attack", typeof(float), typeof(AdsrControl), new PropertyMetadata(0f));


        public float Decay
        {
            get => (float)GetValue(DecayProperty);
            set => SetValue(DecayProperty, value);
        }

        // Using a DependencyProperty as the backing store for Decay.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecayProperty =
            DependencyProperty.Register("Decay", typeof(float), typeof(AdsrControl), new PropertyMetadata(0f));

        public int Sustain
        {
            get => (int)GetValue(SustainProperty);
            set => SetValue(SustainProperty, value);
        }

        // Using a DependencyProperty as the backing store for Sustain.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SustainProperty =
            DependencyProperty.Register("Sustain", typeof(int), typeof(AdsrControl), new PropertyMetadata(0));

        public float Release
        {
            get => (float)GetValue(ReleaseProperty);
            set => SetValue(ReleaseProperty, value);
        }

        // Using a DependencyProperty as the backing store for Release.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReleaseProperty =
            DependencyProperty.Register("Release", typeof(float), typeof(AdsrControl), new PropertyMetadata(0f));


        public AdsrControl()
        {
            InitializeComponent();
        }
    }
}
