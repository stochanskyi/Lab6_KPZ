using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab5.presentation.common
{
    class ClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ClickCommand(Action<object> executionAction, Func<object, bool> canBeExecuted = null)
        {
            this.ExecutionAction = executionAction;
            this.CanBeExecuted = canBeExecuted;
        }

        private Action<object> ExecutionAction;
        private Func<object, bool> CanBeExecuted;

        public bool CanExecute(object parameter) => CanBeExecuted?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => ExecutionAction.Invoke(parameter);
    }
}