using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
 
namespace LostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private static string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=lost_in_the_woods;SslMode=None";
        }
        internal static IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public static void Add(Trail Info)
        {
            using (IDbConnection cnx = Connection) {
                string query = "INSERT INTO trails (name, description, length, elevation_change, longitude, latitude, created_at, updated_at) VALUES (@name, @description, @length, @elevation_change, @longitude, @latitude, NOW(), NOW());";
                cnx.Open();
                cnx.Execute(query, Info);
            }
        }

        public static Trail GetTrailById(int id)
        {
            using (IDbConnection cnx = Connection) {
                string query = $"SELECT * FROM trails WHERE id = '{id}';";
                cnx.Open();
                return cnx.QueryFirstOrDefault<Trail>(query);
            }        
        }

        public static IEnumerable<Trail> GetAllTrails()
        {
            using (IDbConnection cnx = Connection) {
                string query = $"SELECT * FROM trails ORDER BY created_at DESC";
                cnx.Open();
                return cnx.Query<Trail>(query);
            }     
        }
    }
}