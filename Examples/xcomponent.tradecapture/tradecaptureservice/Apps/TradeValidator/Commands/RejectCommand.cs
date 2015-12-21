using System;
using System.Windows.Input;

namespace WpfApplication1.Commands
{
    public class RejectCommand : ICommand
    {
        private readonly TransactionLine line;

        public RejectCommand(TransactionLine line)
        {
            this.line = line;
        }

        public void Execute(object parameter)
        {
            line.Reject();
        }

        public bool CanExecute(object parameter)
        {
            if (line.State == TransactionState.Error)
                return true;

            return false;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
