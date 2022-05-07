﻿using System;
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
    public class BaseVM : INotifyPropertyChanged
    {
   
        public RoutingCommand RoutingCommand { get; set; }//if button pressed on View model

        public event PropertyChangedEventHandler PropertyChanged;//event type to handle property changed
        private void OnPropertyChanged(string propertyName)//fires event
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//make sure event exists and invoke a event if property changes in view or model
        }


        private ObservableCollection<Pokemon> availablePokemon;
        public ObservableCollection<Pokemon> AvailablePokemon
        {
            get { return availablePokemon; }
            set 
            { 
              availablePokemon = value; 
              OnPropertyChanged("AvailablePokemon"); 
            }
        }

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
                if (value != null)
                {
                    selectedPokemon = value;
                    OnPropertyChanged("SelectedPokemon");
                    OpenSelectedPokemonPokedexEntry();
                }
            }
        }


        public BaseVM()
        {
            SelectedArea = "Available Pokemon in Kanto:";
            
            AvailablePokemon = PokemonDataAccess.Dex;
    
           
            RoutingCommand = new RoutingCommand(this);
         
            
        }

        public void UpdateGird(object Area)//whenever a region on the map is selected, update vm 
        {
            string newArea = Area.ToString();
            if(newArea.Contains("Kanto"))
            {
                AvailablePokemon = PokemonDataAccess.Dex;
                SelectedArea = "Available Pokemon in Kanto:";
                return;
            }
            else if (newArea.Contains("Route"))
            {
                newArea = newArea + ",";
                SelectedArea = "Available Pokemon on " + newArea + ":";
            }
            else
            {
                SelectedArea = "Available Pokemon in " + newArea + ":";
            }
            var Pokemonfilter = PokemonDataAccess.Dex.Where(pokemon => pokemon.Location.Contains(newArea));
            AvailablePokemon =  new ObservableCollection<Pokemon>(Pokemonfilter);

        }

        public void OpenSelectedPokemonPokedexEntry()//whenever pokemon is selected on grid 
        {
            
            EntryWindow pokedexPage = new EntryWindow(selectedPokemon);
            
            pokedexPage.Activate();
            
        }
    }
}
