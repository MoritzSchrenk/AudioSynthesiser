using AudioSynthesiser.Model;
using AudioSynthesiser.ViewModel.Converters;
using NAudio.Wave.SampleProviders;
using NUnit.Framework;
using System.Windows.Data;

namespace AudioSynthesiserTests
{
    public class ConverterTests
    {
        [Test]
        public void TestConvertBoolConverter()
        {
            var converter = new NegateBoolConverter();
            var convertedValue = converter.Convert(true, typeof(bool), null, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(false, convertedValue);

            var convertedBackValue = converter.ConvertBack(convertedValue, typeof(bool), null, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(true, convertedBackValue);
        }

        [Test]
        public void TestQuadraticNumberConverter()
        {
            var converter = new QuadraticNumberConverter();

            var convertedValue = converter.Convert(25, typeof(double), null, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(5, convertedValue);

            var convertedBackValue = converter.ConvertBack(convertedValue, typeof(int), null, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(25, convertedBackValue);
        }

        [Test]
        public void TestQuadraticNumberConverterWithNonSquareNumber()
        {
            var converter = new QuadraticNumberConverter();

            var convertedValue = converter.Convert(20, typeof(bool), null, System.Globalization.CultureInfo.InvariantCulture);
            var convertedBackValue = converter.ConvertBack(convertedValue, typeof(bool), null, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(20, convertedBackValue);
        }

        [Test]
        public void TestEnumToBooleanConverter()
        {
            var converter = new EnumToBooleanConverter();
            var convertedValue = converter.Convert(SignalGeneratorType.Sin, typeof(bool), SignalGeneratorType.Sin, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(true, convertedValue);

            convertedValue = converter.Convert(FilterType.LowPass, typeof(bool), FilterType.HighPass, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(false, convertedValue);

            convertedValue = converter.Convert(SignalGeneratorType.Square, typeof(bool), FilterType.Notch, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(false, convertedValue);

            var convertedBackValue = converter.ConvertBack(true, typeof(SignalGeneratorType), SignalGeneratorType.Triangle, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(convertedBackValue, SignalGeneratorType.Triangle);

            convertedBackValue = converter.ConvertBack(false, typeof(SignalGeneratorType), SignalGeneratorType.Triangle, System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(convertedBackValue, Binding.DoNothing);
        }
    }
}