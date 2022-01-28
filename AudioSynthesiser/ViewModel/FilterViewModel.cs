using AudioSynthesiser.Model;
using System.ComponentModel;

namespace AudioSynthesiser.ViewModel
{
    class FilterViewModel : INotifyPropertyChanged
    {
        private Filter filter;

        public Filter Filter
        {
            get { return filter; }
            set { 
                filter = value;
                OnPropertyChanged("Filter");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
