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

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        #endregion

        #region MouseWheel
        private RelayCommand<MouseWheelEventArgs> _mouseWheelCommand;
        public ICommand MouseWheelCommand
        {
            get
            {
                return this._mouseWheelCommand ??

                     (this._mouseWheelCommand = new RelayCommand<MouseWheelEventArgs>(this.ExecuteMouseWheel));
            }
        }
        private void ExecuteMouseWheel(MouseWheelEventArgs e)
        {
            this.MouseWheel(e.Delta);
        }
        private void MouseWheel(int delta)
        {
            if (delta > 0)
            {
                //this.SlideValue++;
            }
            else
            {
                // this.SlideValue--;
            }

        }
        #endregion

        #region TextChanged

        #endregion
    }
}
