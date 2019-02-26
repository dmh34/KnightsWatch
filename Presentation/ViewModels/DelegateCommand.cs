/*
 * Author: D.Hall
 * Created: 8/7/18
*/

using System;
using System.Windows.Input;


namespace Presentation.Commands
{
    public class DelegateCommand : ICommand
    {
        
        public event EventHandler CanExecuteChanged
        {

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }
        private Func<bool> _CanExecute;
        private Action _execute;

        public DelegateCommand(Action Execute, Func<bool> canExecute)
        {
            _execute = Execute;
            _CanExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            if (_CanExecute == null)
                return true;
            var result = _CanExecute.Invoke();
            return result;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }


}
