using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LetsGoDexTracker.ViewModels.Commands
{
    public class RoutingCommand : ICommand
    {
        BaseVM  VM { get; set; }
        public RoutingCommand(BaseVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(parameter is string)
            {
                return true;
            }    
            return false;
        }

        public void Execute(object parameter)
        {
            VM.UpdateGird(parameter);
        }
    }
}
