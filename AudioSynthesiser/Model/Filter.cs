using System.ComponentModel;

namespace AudioSynthesiser.Model
{
    public class Filter
    {
        private float frequency;
        private float q;
        private FilterType type;

        public Filter(FilterType type, float frequency, float q)
        {
            this.type = type;
            this.frequency = frequency;
            this.q = q;
        }

        public float Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
                //OnPropertyChanged("Frequency");
            }
        }
        public float Q
        {
            get => q;
            set
            {
                q = value;
                //OnPropertyChanged("Q");
            }
        }

        public FilterType Type
        {
            get => type;
            set
            {
                type = value;
                //OnPropertyChanged("Type");
            }
        }
    }
}
