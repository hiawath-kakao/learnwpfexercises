using System;
using System.Windows.Input;

namespace Util
{
    public class RelayCommand<T> : ICommand
    {

        #region MyRegion


        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((T)parameter);
        }


        event EventHandler? ICommand.CanExecuteChanged
        {
            add
            {
                //CommandManager.RequerySuggested += value;
            }

            remove
            {
                //CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        bool ICommand.CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        void ICommand.Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region TextChanged

        #endregion
    }
}
