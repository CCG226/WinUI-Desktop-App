using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.Sqlite;
using LetsGoDexTracker.PokemonModel;
using System.IO;
using Windows.Storage;
using System.Collections.ObjectModel;

namespace LetsGoDexTracker.Service
{

    public class PokemonDataAccess
    {
        public static string SELECTALL = "SELECT ID, DexID, Name, Image, PrimaryType, SecondaryType, Entry, location, LevelUp, Height, Weight, Abilities1, Abilities2, Hidden, Category, Availability, HP, Attack, Defense, SpA, SpD, Speed, Total  from [pokedex]";
      
        
        public static ObservableCollection<Pokemon> DataAccess()
        {

            ObservableCollection<Pokemon> Dex = new ObservableCollection<Pokemon>();

            
            string dbpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Database\KantoPokedex.db");

            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                SqliteCommand insert = new SqliteCommand(SELECTALL, db);
                SqliteDataReader query = insert.ExecuteReader();
                while (query.Read())
                {
                    Dex.Add(new Pokemon() { 
                        
                        Id = Convert.ToInt32(query[0]),
                        DexID = Convert.ToString(query[1]),
                        Name = Convert.ToString(query[2]),
                        Image = Convert.ToString(query[3]),
                        PrimaryType = Convert.ToString(query[4]),
                        SecondaryType = Convert.ToString(query[5]),
                        DexEntry = Convert.ToString(query[6]),
                        Location = Convert.ToString(query[7]),
                        Evolve = Convert.ToString(query[8]),
                        Height = Convert.ToString(query[9]),
                        Weight = Convert.ToDecimal(query[10]),
                        Abilities1 = Convert.ToString(query[11]),
                        Abilities2 = Convert.ToString(query[12]),
                        Hidden = Convert.ToString(query[13]),
                        Category = Convert.ToString(query[14]),
                        Exclusivity = Convert.ToInt32(query[15]),
                        HP = Convert.ToInt32(query[16]),
                        Attack = Convert.ToInt32(query[17]),
                        Defense = Convert.ToInt32(query[18]),
                        Special_Attack = Convert.ToInt32(query[19]),
                        Special_Defense = Convert.ToInt32(query[20]),
                        Speed = Convert.ToInt32(query[21]),
                        Base_Stats = Convert.ToInt32(query[22])

                    
                    });
                }
             
                db.Close();
            }
            return Dex;
        }

    }
}