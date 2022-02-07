using System;
using System.Windows.Input;

namespace AudioSynthesiser.ViewModel.Commands
{
    /// <summary>
    /// Command to stop playing a sound
    /// </summary>
    public class SynthStopCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SynthesiserViewModel VM { get; set; }

        public SynthStopCommand(SynthesiserViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null && (parameter is bool ? (bool)parameter : false);
        }

        public void Execute(object parameter)
        {
            VM.Synthesiser.Stop();
        }
    }
}
