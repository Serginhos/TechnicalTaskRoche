using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RocheTechnicalTask.UIWPF.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public TextFileVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCommand(TextFileVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            string text = parameter as string;

            if (string.IsNullOrWhiteSpace(text))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MakeQuery();

        }
    }
}
