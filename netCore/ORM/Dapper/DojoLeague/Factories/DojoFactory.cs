using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using DojoLeague.Models;
using System.Collections.Generic;
using System.Linq;

namespace DojoLeague.Factories
{

    public class DojoFactory : IFactory<Dojo>
    {
        private static string connectionString;
        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=DojoLeague;SslMode=None";
        }
        internal static IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Dojo info){
            using (IDbConnection cnx = Connection){
                string query = "INSERT INTO dojos (name, location, additional_information, created_at, updated_at) VALUES (@name, @location, @additional_information, NOW(), NOW());";
                cnx.Open();
                cnx.Execute(query, info);
            }
        }

        public static Dojo GetDojoById(int id){
            using (IDbConnection cnx = Connection){
                string query = $"SELECT * FROM dojos WHERE id = '{id}'; SELECT * FROM ninjas WHERE dojo_id = '{id}';";
                cnx.Open();
                using (var multi = cnx.QueryMultiple(query, new {Id = id}))
                {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }

        public static List<Dojo> GetAllDojos(){
            using (IDbConnection cnx = Connection){
                string query = "SELECT * FROM dojos;";
                cnx.Open();
                return cnx.Query<Dojo>(query).ToList();      
            }
        }
    }
}