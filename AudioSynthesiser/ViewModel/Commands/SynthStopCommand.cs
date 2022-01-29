using System;
using System.Windows.Input;

namespace AudioSynthesiser.ViewModel
{
    public class SynthStopCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SynthesiserViewModel VM { get; set; }

        public SynthStopCommand(SynthesiserViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Synth.Stop();
        }
    }
}
