﻿using NAudio.Dsp;
using NAudio.Wave;

namespace AudioSynthesiser.Synth
{
    public class FilterProvider : ISampleProvider
    {
        private readonly ISampleProvider sourceProvider;
        private readonly IFilter filter;

        public FilterProvider(ISampleProvider sourceProvider, IFilter filter)
        {
            this.sourceProvider = sourceProvider;
            this.filter = filter;
        }

        public WaveFormat WaveFormat => sourceProvider.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = sourceProvider.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                buffer[offset + n] = filter.Transform(buffer[offset + n]);
            }

            return samplesRead;
        }
    }
}