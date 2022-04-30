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
            set {  pokemonEntry = value;}
        }
        public string PokedexID
        {
            get
            {
                return "Pokedex ID:" + pokemonEntry.DexID;
            }
        }
        public string Exclusivity
        {
            get
            {
                if (pokemonEntry.Exclusivity == 2)
                {
                    return "EXCLUSIVE: LETS GO PICKACHU ONLY!";
                }
                else if(pokemonEntry.Exclusivity == 3)
                {
                    return "EXCLUSIVE: Lets Go EEVEE ONLY!";
                }
                else
                {
                    return null;
                }
            }
        }
        public string FirstAbility
        {
            get
            {
                if(pokemonEntry.Abilities1 != null)
                {
                    return pokemonEntry.Abilities1;
                }
                else { return "None"; }

            }
        }
        public string SecondAbility
        {
            get
            {
                if (pokemonEntry.Abilities2 != null)
                {
                    return pokemonEntry.Abilities2;
                }
                else { return "None"; }

            }
        }
        public string HiddenAbility
        {
            get
            {
                if(pokemonEntry.Hidden != null)
                {
                    return PokemonEntry.Hidden;
                }
                else {  return "None"; }
            }
        }
        public string EvolutionLine
        {
            get
            {
                if(pokemonEntry.Evolve.Contains("Level"))
                {
                    return "Evolves at " + pokemonEntry.Evolve;
                }
                else if(pokemonEntry.Evolve == null)
                {
                    return null;
                }
                else
                {
                    return "Evolves via " + pokemonEntry.Evolve;
                }
            }
        }
    }
}
