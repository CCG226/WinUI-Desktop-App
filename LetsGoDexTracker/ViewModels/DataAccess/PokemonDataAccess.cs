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
using LetsGoDexTracker.ViewModels.DataAccess;

namespace LetsGoDexTracker.Service
{

    public class PokemonDataAccess
    {
        public static string SELECTALL = "SELECT ID, DexID, captured, Name, Image, PrimaryType, SecondaryType, Entry, location, LevelUp, Height, Weight, Abilities1, Abilities2, Hidden, Category, Availability, HP, Attack, Defense, SpA, SpD, Speed, Total  from [pokedex]";
      
        public static ObservableCollection<Pokemon> Dex = new ObservableCollection<Pokemon>();

        public static void DataAccess()
        {

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
                        isChecked = Convert.ToString(query[2]),
                        Name = Convert.ToString(query[3]),
                        Image = Convert.ToString(query[4]),
                        PrimaryType = Convert.ToString(query[5]),
                        SecondaryType = Convert.ToString(query[6]),
                        DexEntry = Convert.ToString(query[7]),
                        Location = Convert.ToString(query[8]),
                        Evolve = Convert.ToString(query[9]),
                        Height = Convert.ToString(query[10]),
                        Weight = Convert.ToDecimal(query[11]),
                        Abilities1 = Convert.ToString(query[12]),
                        Abilities2 = Convert.ToString(query[13]),
                        Hidden = Convert.ToString(query[14]),
                        Category = Convert.ToString(query[15]),
                        Exclusivity = Convert.ToInt32(query[16]),
                        HP = Convert.ToInt32(query[17]),
                        Attack = Convert.ToInt32(query[18]),
                        Defense = Convert.ToInt32(query[19]),
                        Special_Attack = Convert.ToInt32(query[20]),
                        Special_Defense = Convert.ToInt32(query[21]),
                        Speed = Convert.ToInt32(query[22]),
                        Base_Stats = Convert.ToInt32(query[23])

                    
                    });
                }
                for(int i = 0; i < Dex.Count; i++)
                {
                 Dex[i].bColor = TypeLookUpChart.TypeBubble(Dex[i].PrimaryType);
                }
                db.Close();
            }
          
        }

    }
}