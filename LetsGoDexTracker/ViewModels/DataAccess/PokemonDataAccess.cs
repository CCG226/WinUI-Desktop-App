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
        //select all fields  of every record in pokedex table 
        public const string READ = "SELECT ID, DexID, captured, Name, Image, PrimaryType, SecondaryType, Entry, location, LevelUp, Height, Weight, Abilities1, Abilities2, Hidden, Category, Availability, HP, Attack, Defense, SpA, SpD, Speed, Total  from [pokedex]";
        //update a records captured field
        public const string WRITE = $"UPDATE [pokedex] SET captured = @check WHERE ID = @id";

       //stores pokedex read from sqllite database
        public static ObservableCollection<Pokemon> Dex = new ObservableCollection<Pokemon>();

        public static void DataAccess()
        {
            //path to local file : (LetsGoDexTracker\LetsGoDexTracker\bin\x86\Debug\net6.0-windows10.0.19041.0\win10-x86\AppX\Database)
            string dbpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Database\KantoPokedex.db");

            //opens a connection instance named db to the database file 
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();//explitly open a connection 

                //create a instance of a sqlite command to read all records from the pokedex table into a collection of pokemon object records named Dex with the sqlite connection instance
                SqliteCommand insert = new SqliteCommand(READ, db);
                //send sql command to the connection to create a sql data reader named query (creates the query)
                SqliteDataReader query = insert.ExecuteReader();
               
                //move through all the rows iteraively and stop when their are no more rows left
                while (query.Read())
                {
                    //record = individual pokemon object
                    Dex.Add(new Pokemon() { //for every record create a element in the Dex array
                        //query[index] equals the corresponding field in the sql string READ command text
                        //so query[0] = the records first field (ID)
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
                for(int i = 0; i < Dex.Count; i++)//bonus field in the pokemon object, used only for bordecolor on the myDex page
                {
                 Dex[i].bColor = TypeLookUpChart.TypeBubble(Dex[i].PrimaryType);
                }
                db.Close();//explictly close the connection 
            }
          
        }

        public static void DataUpdate(Pokemon pokemon)
        {
            //path to local file : (LetsGoDexTracker\LetsGoDexTracker\bin\x86\Debug\net6.0-windows10.0.19041.0\win10-x86\AppX\Database)
            string dbpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Database\KantoPokedex.db");
            //opens a connection instance named db to the database file 
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();//explitly open a connection 
                //creates a command object instance 
                SqliteCommand insertCommand = new SqliteCommand();
               //sets command to db connection
                insertCommand.Connection = db;
                //command text = WRITE command, which updates a specific records field 
                insertCommand.CommandText = WRITE;
               //sql injection attack prevention, dosent matter for this project but good practice 
                insertCommand.Parameters.AddWithValue("@check", pokemon.isChecked);
                insertCommand.Parameters.AddWithValue("@id", pokemon.Id);
                //execute sql command statement which will update the checkmark of a pokemon record storeing the change in the sql file
                insertCommand.ExecuteReader();
            
                db.Close();//explitly closes the connection 
            }
        }
    }
}