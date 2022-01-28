using System;
using System.Collections.Generic;
using System.Text;

namespace AudioSynthesiser.ViewModel
{
    public class Filter
    {
        public float Frequency { get; set; }
        public float Q { get; set; }

        public FilterType Type { get; set; }

        public Filter(FilterType type, float q, float frequency)
        {
            Type = type;
            Q = q;
            Frequency = frequency;
        }
    }

    public enum FilterType
    {
        Off,
        LowPass,
        HighPass,
        BandPass,
        Notch
    }
}
