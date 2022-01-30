using AudioSynthesiser.Synth;
using NAudio.Dsp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioSynthesiserTests
{
    public class ComponentTests
    {
        [Test]
        public void TestLFO()
        {
            var sourceSample = new DummySampleProvider(new float[] { 1, 2, 1, 2 });
            var lfoSignal = new DummySampleProvider(new float[] { 0.1f, 0, -0.1f, 0 });

            var lfo = new LfoProvider(sourceSample, lfoSignal);

            var results = new float[4];
            var samples = lfo.Read(results, 0, 4);

            Assert.AreEqual(4, samples);
            Assert.AreEqual(new float[] { 1.1f, 2, 0.9f, 2 }, results);
        }

        [Test]
        public void TestFilter()
        {
            var sourceSample = new DummySampleProvider(new float[] { 1, 2, 3, 2 });

            var filter = new FilterProvider(sourceSample, new DummyFilter(i => i-=2));

            var results = new float[4];
            var samples = filter.Read(results, 0, 4);

            Assert.AreEqual(4, samples);
            Assert.AreEqual(new float[] { -1, 0, 1, 0 }, results);
        }
    }
}
