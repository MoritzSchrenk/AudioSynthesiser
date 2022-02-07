using System;
using System.Windows.Input;

namespace AudioSynthesiser.ViewModel.Commands
{
    /// <summary>
    /// Command to play sound
    /// </summary>
    public class SynthPlayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SynthesiserViewModel VM { get; set; }

        public SynthPlayCommand(SynthesiserViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null && (parameter is bool ? (bool)parameter : false);
        }

        public void Execute(object parameter)
        {
            VM.Synthesiser.Play();
        }
    }
}
