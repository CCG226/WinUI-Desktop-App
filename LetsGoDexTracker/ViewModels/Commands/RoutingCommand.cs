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
        BaseVM  VM { get; set; }//property for Home page view model, the page this button is attacked too
        public RoutingCommand(BaseVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;//occurs when command change is noticed 

        public bool CanExecute(object parameter)
        {
            if(parameter is string)//if command parameter of map button is a string which it should be, execute command
            {
                return true;
            }    
            return false;
        }

        public void Execute(object parameter)
        {
            //update grid, paramter is command paramater of region selected, 
            //example:if Route 21 is selected, "Route 21" is passed as paramter
            //we can then sort a new gridview list of pokemon who have the location Route 21
            //then update the grid view 
            VM.UpdateGird(parameter);
        }
    }
}
