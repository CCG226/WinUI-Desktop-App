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

        private string selectedArea;
        public string SelectedArea
        {
            get { return selectedArea; }
            set
            {
                selectedArea = value;
                OnPropertyChanged("SelectedArea");
            }
        }

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
         
        public ObservableCollection<Pokemon> AvailablePokemon { get; set; }

        public BaseVM()
        {
            SelectedArea = "Available Pokemon in Kanto:";
            
            AvailablePokemon = PokemonDataAccess.DataAccess();
           
            RoutingCommand = new RoutingCommand(this);

            
        }

        public void UpdateGird(object Area)//whenever a region on the map is selected, update vm 
        {
            string newArea = Area.ToString();
            if(newArea.Contains("Kanto"))
            {
                var all = AvailablePokemon.Where(pokemon => !pokemon.Name.Equals(null));
                AvailablePokemon = new ObservableCollection<Pokemon>(all);
                SelectedArea = "Available Pokemon in Kanto:";
            }
            else if (newArea.Contains("Route"))
            {
                SelectedArea = "Available Pokemon on " + newArea + ":";
            }
            else
            {
                SelectedArea = "Available Pokemon in " + newArea + ":";
            }
            var Pokemonfilter = AvailablePokemon.Where(pokemon => pokemon.Location.Contains(newArea));
            AvailablePokemon = new ObservableCollection<Pokemon>(Pokemonfilter);

        }

        public void OpenSelectedPokemonPokedexEntry(Pokemon pokemon)//whenever pokemon is selected on grid 
        {

        }
    }
}
