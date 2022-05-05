using LetsGoDexTracker.PokemonModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoDexTracker.Service;
using LetsGoDexTracker.ViewModels.Commands;
using LetsGoDexTracker.ViewModels.DataAccess;

namespace LetsGoDexTracker.ViewModels
{
    public class UserDexVM: INotifyPropertyChanged
    {
        public ObservableCollection<Pokemon> myPokedex { get; set; }

        private Pokemon selectedPokemon;
        public Pokemon SelectedPokemon
        {
            get { return selectedPokemon; }
            set
            {
                if (value != null)
                {
                    selectedPokemon = value;
                    OnPropertyChanged("SelectedPokemon");
         
                }
            }
        }

        public UserDexVM()
        {
            myPokedex = PokemonDataAccess.Dex;
            SelectedCommand = new SelectedCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)//fires event
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//make sure event exists and invoke a event if property changes in view or model
        }

        public void SwapMarks(Pokemon selected)
        {
            if (selected.isChecked == "/Assets/isChecked.png")
            {
                selected.isChecked = "/Assets/isNotChecked.png";
            }
            else
            {
                selected.isChecked = "/Assets/isChecked.png";
            }

        }

        public SelectedCommand SelectedCommand { get; set; }

    }
}
