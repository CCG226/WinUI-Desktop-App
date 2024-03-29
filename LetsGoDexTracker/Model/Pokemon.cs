﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoDexTracker.PokemonModel
{
    public class Pokemon//pokemon object, based on the pokemon record from the pokedex table in the database
    {
        public int Id { get; set; }
        
        public string DexID { get; set; }
        
        public string Name { get; set; }
        
        public string Image { get; set; }
        
        public string PrimaryType { get; set; }

        public string SecondaryType {get; set; }
        
        public string DexEntry { get; set; }
        
        public string Location { get; set; }
        
        public string Evolve { get; set; }
        
        public string Height { get; set; }
        
        public decimal Weight { get; set; }

        public string Abilities1 { get; set; }
        
        public string Abilities2 { get; set; }

        public string Hidden { get; set; }

        public string Category { get; set; }

        public int Exclusivity { get; set; }

        public int HP { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Special_Attack { get; set; } 

        public int Special_Defense { get; set; }

        public int Speed { get; set; }

        public int Base_Stats { get; set; }

        public string bColor { get; set; }

        public string isChecked { get; set; }
    }
}
