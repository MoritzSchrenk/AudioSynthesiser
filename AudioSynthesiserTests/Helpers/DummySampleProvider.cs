using NAudio.Wave;
using System;

namespace AudioSynthesiserTests.Helpers
{
    public class DummySampleProvider : ISampleProvider
    {
        public WaveFormat WaveFormat => new WaveFormat();

        private float[] _values;

        public DummySampleProvider(float[] values)
        {
            _values = values;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            Array.Copy(_values, buffer, count);
            return buffer.Length;
        }
    }
}
