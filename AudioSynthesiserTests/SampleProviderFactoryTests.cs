using NUnit.Framework;
using AudioSynthesiser.Synth.SampleProviders;
using AudioSynthesiser.Model;
using AudioSynthesiserTests.Helpers;
using NAudio.Wave.SampleProviders;
using Moq;

namespace AudioSynthesiserTests
{
    public class SampleProviderFactoryTests
    {
        [Test]
        public void TestChainingSampleProviderBuilder()
        {
            var sourceSample = new DummySampleProvider(new float[] { 1, 2, 1, 3 });
            var lfoSignal = new DummySampleProvider(new float[] { 0.1f, 0, -0.1f, 0 }); //1.1, 2, 0.9, 3

            var lfoProvider = new LfoProvider(sourceSample, lfoSignal);
            var filter = new FilterProvider(lfoProvider, new DummyFilter(i => i -= 2)); //-0.9, 0, -1.1, 1
            var volume = new VolumeSampleProvider(filter) { Volume = 0.5f }; // -0.45, 0, -0.55, 0.5

            var mockSampleProviderBuilder = new Mock<ISampleProviderBuilder>();
            mockSampleProviderBuilder.Setup(x => x.WithSignalGenerator(It.IsAny<Oscillator>())).Returns(mockSampleProviderBuilder.Object);
            mockSampleProviderBuilder.Setup(x => x.WithLfo(It.IsAny<Oscillator>())).Returns(mockSampleProviderBuilder.Object);
            mockSampleProviderBuilder.Setup(x => x.WithFilter(It.IsAny<Filter>())).Returns(mockSampleProviderBuilder.Object);
            mockSampleProviderBuilder.Setup(x => x.WithVolume(It.IsAny<float>())).Returns(mockSampleProviderBuilder.Object);
            mockSampleProviderBuilder.Setup(x => x.WithEnvelope(It.IsAny<Adsr>())).Returns(mockSampleProviderBuilder.Object);
            mockSampleProviderBuilder.Setup(x => x.GetSampleProvider()).Returns(volume);

            var factory = new SampleProviderFactory(mockSampleProviderBuilder.Object);

            var sampleProvider = factory.BuildSampleProvider();

            var results = new float[4];
            var samples = sampleProvider.Read(results, 0, 4);

            Assert.AreEqual(4, samples);
            Assert.AreEqual(new float[] { -0.45f, 0, -0.55f, 0.5f }, results);
        }
    }
}
