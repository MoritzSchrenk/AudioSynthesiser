using AudioSynthesiser.Model;
using System.ComponentModel;

namespace AudioSynthesiser.ViewModel
{
    public class OscillatorViewModel : INotifyPropertyChanged
    {
        private Oscillator oscillator;

        public Oscillator Oscillator
        {
            get { return oscillator; }
            set {
                oscillator = value;
                OnPropertyChanged("Oscillator");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
