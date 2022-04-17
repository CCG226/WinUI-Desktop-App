using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoDexTracker.ViewModels.Commands;
using LetsGoDexTracker.PokemonModel;
using System.Collections.ObjectModel;
using LetsGoDexTracker.Service;
namespace LetsGoDexTracker.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public SelectedCommand SelectCommand { get; set; }//if gridView is selected

        public RoutingCommand RoutingCommand { get; set; }//if button pressed on View model

        public event PropertyChangedEventHandler PropertyChanged;//event type to handle property changed

        private Pokemon selectedPokemon;
        public Pokemon SelectedPokemon
        {
            get { return selectedPokemon; }
            set
            {
                selectedPokemon = value;
                OnPropertyChanged("SelectedPokemon");
            }
        }

        private void OnPropertyChanged(string propertyName)//fires event
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//make sure event exists and invoke a event if property changes in view or model
        }
         
        public ObservableCollection<Pokemon> Pokedex { get; set; }

        public BaseVM()
        {

            PokemonDataAccess.IntializeData();

            Pokedex = PokemonDataAccess.DataAccess();
        }

        public void UpdateGird(object Area)//whenever a region on the map is selected, update vm 
        {
           
        }

        public void OpenSelectedPokemonPokedexEntry(Pokemon pokemon)//whenever pokemon is selected on grid 
        {

        }
    }
}
