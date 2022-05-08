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
    public class EntryVM//view model for EntryWindow 
    {

        public string PrimaryTypeBoxColor//returns background color of the textblock containing the pokemons primary type 
        {
            //get background color based on pokemons type, ex: if water type return DodgerBlue
            get {  return TypeLookUpChart.TypeBubble(pokemonEntry.PrimaryType);  }
        }
        //returns background color of the textblock containing the pokemons secondary type 
        public string SecondaryTypeBoxColor
        {
            get
            {
                if(PokemonEntry.SecondaryType == "")//if pokemon dosent have a secondary type
                {
                    return "White";//white out that textblock
                }
                else
                {//get background color based on pokemons type, ex: if water type return DodgerBlue
                    return TypeLookUpChart.TypeBubble(pokemonEntry.SecondaryType);
                }
            }
        }

        private static  Pokemon pokemonEntry;  //static property of selected pokemon containing all record info we need about that pokemon 
        public static  Pokemon PokemonEntry
        {
            get { return pokemonEntry; }
            set {  pokemonEntry = value;}
        }

        //formatting and returning a pokemons record information for readability
        public string PokedexID {  get{ return "Pokedex ID:" + pokemonEntry.DexID;}}
        public string Total { get { return "Total: " + PokemonEntry.Base_Stats; } }
        public string HealthPoints { get { return "HP: " + PokemonEntry.HP; } }
        public string Attack {  get { return "Attack: " + PokemonEntry.Attack;  } }
        public string Defense { get { return "Defense: " + PokemonEntry.Defense; } }
        public string SpAttack {  get { return "Special Attack: " + PokemonEntry.Special_Attack; } }
        public string SpDefense { get { return "Special Defense: " + PokemonEntry.Special_Attack; } }
        public string Speed { get { return "Speed: " + PokemonEntry.Speed; } }
 

        public string Exclusivity//a pokemon is exclusive if it can only be found in a specific game, ex: ekans can only be obtained in Lets Go evee
        {
            get
            {
                if (pokemonEntry.Exclusivity == 2)//if a pokemons exclusivity field equals 2 to it is only availiable in Lets Go pikachu
                {
                    return "EXCLUSIVE: LETS GO PICKACHU ONLY!";//return a warning massage at the top of the pokedex entry page under type bubbles 
                }
                else if(pokemonEntry.Exclusivity == 3)//if a pokemons exclusivity field equals 3 to it is only availiable in Lets Go Eevee
                {
                    return "EXCLUSIVE: Lets Go EEVEE ONLY!";//return a warning massage at the top of the pokedex entry page under type bubbles
                }
                else//pokemons exclusivity equals 1 so its available in both games
                {
                    return null;//no message 
                }
            }
        }
        public string FirstAbility//a pokemons primary special ability 
        {
            get
            {
                if(pokemonEntry.Abilities1 != "")//if thier special ability is NOT empty
                {
                    return pokemonEntry.Abilities1;//return text of the name of their special ability to be displayed on the dex page 
                }
                else { return "None"; }//pokemon doenst have primary ability return None text 

            }
        }
        public string SecondAbility//a pokemons secondary special ability 
        {
            get
            {
                if (pokemonEntry.Abilities2 != "")//return text of the name of their special ability to be displayed on the dex page 
                {
                    return pokemonEntry.Abilities2;
                }
                else { return "None"; }//pokemon doenst have secondary ability return None text 

            }
        }
        public string HiddenAbility//a pokemons hidden special ability 
        {
            get
            {
                if(pokemonEntry.Hidden != "")//return text of the name of their hidden ability to be displayed on the dex page 
                {
                    return PokemonEntry.Hidden;
                }
                else {  return "None"; }//pokemon doenst have hidden ability return None text 
            }
        }
        public string EvolutionLine//contains info about how to evolve this pokemon 
        {
            get
            {
                if(pokemonEntry.Evolve.Contains("Level"))//if pokemon evolve info contains Level, then it evolves by leveling up and appropriate text should be returned 
                {
                    return "Evolves at " + pokemonEntry.Evolve;
                }
                else if(pokemonEntry.Evolve == "")//if pokemons evolves text is null, pokemon dosent evolve or is full evolved, return nothing
                {
                    return " ";
                }
                else//pokemon evolves by unqiue method, display appropriate text
                {
                    return "Evolves via " + pokemonEntry.Evolve;
                }
            }
        }
    }
}
