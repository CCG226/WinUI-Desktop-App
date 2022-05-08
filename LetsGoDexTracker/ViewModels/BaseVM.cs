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
using LetsGoDexTracker.Views.PokedexEntryWindow;
using Microsoft.UI.Xaml.Navigation;
namespace LetsGoDexTracker.ViewModels
{
    public class BaseVM : INotifyPropertyChanged//view model for the HOME page 
    {
   
        public RoutingCommand RoutingCommand { get; set; }//if button pressed on View model

        public event PropertyChangedEventHandler PropertyChanged;//event type to handle property changed
        private void OnPropertyChanged(string propertyName)//fires event
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//make sure event exists and invoke a event if property changes in view or model
        }


        private ObservableCollection<Pokemon> availablePokemon;//property for the collection of pokemon in the grid view that are available in the selected region
        public ObservableCollection<Pokemon> AvailablePokemon
        {
            get { return availablePokemon; }
            set 
            { 
              availablePokemon = value; 
              OnPropertyChanged("AvailablePokemon"); 
            }
        }

        private string selectedArea;//property for text above the grid view, updates whenever a region is selected 
        public string SelectedArea
        {
            get { return selectedArea; }
            set
            {
                selectedArea = value;
                OnPropertyChanged("SelectedArea");
            }
        }

        private Pokemon selectedPokemon;//property for the pokemon that is selected on the gridview 
        public Pokemon SelectedPokemon
        {
            get { return selectedPokemon; }
            set
            {
                if (value != null)//saftey check
                {
                    selectedPokemon = value;
                    OnPropertyChanged("SelectedPokemon");
                    OpenSelectedPokemonPokedexEntry();//method to open up a page for the selected pokemons pokedex entry upon selection
                }
            }
        }


        public BaseVM()//intial values when Home page is loaded (constructor for view model)
        {
            SelectedArea = "Available Pokemon in Kanto:";
            //display all pokemon available in the Kanto region
            AvailablePokemon = PokemonDataAccess.Dex;
           //intialize command for the buttons embedded on the interactive map
            RoutingCommand = new RoutingCommand(this);
         
            
        }

        public void UpdateGird(object Area)//whenever a place on the map is selected, update grid view 
        {//Area = command paramter for the routing buttons in the interactive map
            string newArea = Area.ToString();//convert command parameter to a string and store it a copy
            if(newArea.Contains("Kanto"))//if area selected was the Select Entire Region button
            {
                AvailablePokemon = PokemonDataAccess.Dex;//list all pokemon in grid view
                SelectedArea = "Available Pokemon in Kanto:";
                return;//done
            }
            else if (newArea.Contains("Route"))//if a route was selected on the map
            {
                SelectedArea = "Available Pokemon on " + newArea + ":";//text above grid view changes 
                newArea = newArea + ",";//ensures we get the correct pokemon in this route by putting a comma as in the database field for location(s) which is a list of all the areas  a pokemon can be found has a comma after the route number. ex: Route 2,
            }
            else//if a city, cave, special place was selected 
            {
                SelectedArea = "Available Pokemon in " + newArea + ":";//text above grid view changes 
            }
            var Pokemonfilter = PokemonDataAccess.Dex.Where(pokemon => pokemon.Location.Contains(newArea));//use linq to store a list of all pokemon that contains the new area selected on the map in the location field
            AvailablePokemon =  new ObservableCollection<Pokemon>(Pokemonfilter);//update grid view list in the home page with only pokemon from the region selected 

        }

        public void OpenSelectedPokemonPokedexEntry()//whenever a pokemon is selected on grid 
        {
            //parameter for pokedex window is selected pokemon so we can build a unique page 
            EntryWindow pokedexPage = new EntryWindow(selectedPokemon);//intialze instance of a new window for a pokedex page of that pokemon
            
            pokedexPage.Activate();//open up that page 
            
        }
    }
}
