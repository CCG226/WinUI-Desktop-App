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
        

        public BaseVM VM { get; set; }

        public SelectedCommand(BaseVM vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
     
        }
    }
}
