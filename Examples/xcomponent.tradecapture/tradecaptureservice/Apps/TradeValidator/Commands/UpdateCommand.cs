using System;
using System.Windows.Input;

namespace WpfApplication1.Commands
{
    public class UpdateCommand : ICommand
    {
        private readonly TransactionLine line;

        public UpdateCommand(TransactionLine line)
        {
            this.line = line;
        }

        public void Execute(object parameter)
        {
            line.UpdateAndRetry();
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
