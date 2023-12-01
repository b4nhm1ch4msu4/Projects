using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Easy_Note.ViewModel
{
    public class MyCommand : ICommand
    {
        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        public MyCommand(Action targetExecuteMethod)
        {
            _TargetExecuteMethod = targetExecuteMethod;
        }
        public MyCommand(Action targetExecuteMethod, Func<bool> targetCanExecuteMethod)
        {
            _TargetExecuteMethod = targetExecuteMethod;
            _TargetCanExecuteMethod = targetCanExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        public bool CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (_TargetExecuteMethod != null) 
            {
                _TargetExecuteMethod();
            }
        }
    }
}
