using LetsGoDexTracker.PokemonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoDexTracker.Views.PokedexEntryWindow;
using LetsGoDexTracker.Service;
using LetsGoDexTracker.ViewModels.DataAccess;

namespace LetsGoDexTracker.ViewModels
{
    public class EntryVM
    {
        public EntryVM()
        {
            
        }

        public string PrimaryTypeBoxColor
        {
            get
            {
                if (PokemonEntry.PrimaryType == "NULL")
                {
                    return "White";
                }
                else
                {
                    return TypeLookUpChart.TypeBubble(pokemonEntry.PrimaryType);
                }
            }
        }
        public string SecondaryTypeBoxColor
        {
            get
            {
                if(PokemonEntry.SecondaryType == "NULL")
                {
                    return "White";
                }
                else
                {
                    return TypeLookUpChart.TypeBubble(pokemonEntry.SecondaryType);
                }
            }
        }

        private static Pokemon pokemonEntry;  
        public static Pokemon PokemonEntry
        {
            get {
               
                return pokemonEntry; }
            set {  pokemonEntry = value;}
        }

        public string PokedexID {  get{ return "Pokedex ID:" + pokemonEntry.DexID;}}
        public string Total { get { return "Total: " + PokemonEntry.Base_Stats; } }
        public string HealthPoints { get { return "HP: " + PokemonEntry.HP; } }
        public string Attack {  get { return "Attack: " + PokemonEntry.Attack;  } }
        public string Defense { get { return "Defense: " + PokemonEntry.Defense; } }
        public string SpAttack {  get { return "Special Attack: " + PokemonEntry.Special_Attack; } }
        public string SpDefense { get { return "Special Defense: " + PokemonEntry.Special_Attack; } }
        public string Speed { get { return "Speed: " + PokemonEntry.Speed; } }
 
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
                if(pokemonEntry.Abilities1 == "NULL")
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
                if (pokemonEntry.Abilities2 == "NULL")
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
                if(pokemonEntry.Hidden == "NULL")
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
                else if(pokemonEntry.Evolve == "NULL")
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
