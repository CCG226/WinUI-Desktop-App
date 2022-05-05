using LetsGoDexTracker.PokemonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LetsGoDexTracker.ViewModels.Commands
{
    public class SelectedCommand : ICommand
    {
        

        public UserDexVM VM { get; set; }

        public SelectedCommand(UserDexVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            Pokemon selected = parameter as Pokemon;
            if(selected != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Pokemon selected = parameter as Pokemon;

            VM.SwapMarks(selected);

        }
    }
}
