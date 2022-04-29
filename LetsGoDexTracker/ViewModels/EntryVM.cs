using LetsGoDexTracker.PokemonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoDexTracker.Views.PokedexEntryWindow;
namespace LetsGoDexTracker.ViewModels
{
    public class EntryVM
    {
        private static Pokemon pokemonEntry;  
        public static Pokemon PokemonEntry
        {
            get {
               
                return pokemonEntry; }
            set { pokemonEntry = value; 

            }
        }
        public string FormatIDOutput = "Pokedex ID:" + pokemonEntry.DexID;
        public EntryVM()
        {
        }
    }
}
