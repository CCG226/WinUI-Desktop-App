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

namespace LetsGoDexTracker.Service
{
    public class DataAccessService
    {
        public static List<Pokemon> DataAccess()
        {
            List<Pokemon> Dex = new List<Pokemon>();
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path,"NationalPokedex.db");

            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                SqliteCommand insert = new SqliteCommand("SELECT * from ID", db);
                SqliteDataReader query = insert.ExecuteReader();
                while(query.Read())
                {
                    Dex.Add(new Pokemon() { Id = query.GetInt16(0) });
                }
             
                db.Close();
            }
            return Dex;
        }
        
    }
}
