using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetsGoDexTracker.Model;
namespace LetsGoDexTracker.ViewModels.DataAccess
{
    public class TypeLookUpChart
    {

        public static string TypeBubble(string pokemonsType) //parameter = pokemon records primary/secondary type field
        {
            var typecolor = pokemonsType switch//switch expression that turns a type name into a color for dyanmic color backgrounds for pokedex entries 
            {
                nameof(TypeEnums.Normal) => "Tan",
                nameof(TypeEnums.Fighting) => "Firebrick",
                nameof(TypeEnums.Flying) => "PowederBlue",
                nameof(TypeEnums.Poison) => "DarkOrchid",
                nameof(TypeEnums.Ground) => "SandyBrown",
                nameof(TypeEnums.Rock) => "SaddleBrown",
                nameof(TypeEnums.Bug) => "YellowGreen",
                nameof(TypeEnums.Ghost) => "DarkSlateBlue",
                nameof(TypeEnums.Steel) => "Silver",
                nameof(TypeEnums.Fire) => "OrangeRed",
                nameof(TypeEnums.Water) => "DodgerBlue",
                nameof(TypeEnums.Grass) => "ForestGreen",
                nameof(TypeEnums.Electric) => "Gold",
                nameof(TypeEnums.Psychic) => "DeepPink",
                nameof(TypeEnums.Ice) => "PaleTurquoise",
                nameof(TypeEnums.Dragon) => "DarkCyan",
                nameof(TypeEnums.Dark) => "DarkSlateGray",
                nameof(TypeEnums.Fairy) => "HotPink",
                _ => null
            };

            return typecolor;
        }
    }
}
