using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LetsGoDexTracker.ViewModels
{
    public class RelayCommand: ICommand//for defining a command behaviour of interactive UI object 
    {

        private readonly Func<bool> _canExecute;
        private readonly Action _execute;
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
        public void RaiseCanExecuteChanged()
        {
            var handle = CanExecuteChanged;
            if (handle != null)
            {
                handle(this, EventArgs.Empty);
            }
        }
    }
}
