using AudioSynthesiser.Synth;
using AudioSynthesiser.View;
using System.Windows;

namespace AudioSynthesiser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DependencyInjector.Register<ISynthesiser, Synthesiser>();
            MainWindow = DependencyInjector.Retrieve<MainWindow>();
            MainWindow.Show();
        }
    }
}
