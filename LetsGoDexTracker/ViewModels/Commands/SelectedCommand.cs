﻿using LetsGoDexTracker.PokemonModel;
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
        public event EventHandler CanExecuteChanged;//occurs when command change is noticed 

        public bool CanExecute(object parameter)
        {
            Pokemon pokemon = parameter as Pokemon;
            if (pokemon != null)
            { 
                return true;
            }
            return false;

        }

        public void Execute(object parameter)
        {
            Pokemon pokemon = parameter as Pokemon;
            VM.SwapMarks(pokemon);
        }
    }
}
