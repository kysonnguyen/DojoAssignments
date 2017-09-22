using System.Data;
using DojoLeague.Factories;
using MySql.Data.MySqlClient;
using Dapper;
using DojoLeague.Models;
using System.Collections.Generic;
using System.Linq;

namespace DojoLeague.Factories{

    public class NinjaFactory : IFactory<Dojo>
    {
        private static string connectionString;
        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=dojoleague;SslMode=None";
        }
        internal static IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public static void Add(Ninja info){
            using (IDbConnection cnx = Connection){
                string query;
                if(info.dojo_id != 0){
                    query = "INSERT INTO ninjas (name, level, description, dojo_id, created_at, updated_at) VALUES (@name, @level, @description, @dojo_id, NOW(), NOW())";
                }
                else{
                    query = "INSERT INTO ninjas (name, level, description, created_at, updated_at) VALUES (@name, @level, @description, NOW(), NOW())";
                }
                cnx.Open();
                cnx.Execute(query, info);
            }
        }

        public static List<Ninja> GetDojoNinjas(){
            using (IDbConnection cnx = Connection){
                string query = "SELECT * FROM ninjas JOIN dojos on ninjas.dojo_id WHERE dojos.id = ninjas.dojo_id";
                cnx.Open();
                return cnx.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; }).ToList();
            }
        }

        public static List<Ninja> GetRogueNinjas(){
            using (IDbConnection cnx = Connection){
                string query = "SELECT * FROM ninjas WHERE dojo_id IS NULL";
                cnx.Open();
                return cnx.Query<Ninja>(query).ToList();
            }
        }

        public static Ninja GetNinjaById(int id){
            using (IDbConnection cnx = Connection){
                string query = $"SELECT * FROM ninjas JOIN dojos on ninjas.dojo_id WHERE dojos.id = ninjas.dojo_id && ninjas.id = {id};";
                cnx.Open();
                return cnx.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja;}).SingleOrDefault() as Ninja;
            }
        }

        public static Ninja GetRogueNinjaById(int id){
            using (IDbConnection cnx = Connection){
                string query = $"SELECT * FROM ninjas WHERE id = {id}";
                cnx.Open();
                return cnx.Query<Ninja>(query).SingleOrDefault() as Ninja;
            }
        }

        public static void Recruit(int dojo_id, int ninja_id){
            using (IDbConnection cnx = Connection){
                string query = $"UPDATE ninjas SET dojo_id = {dojo_id} WHERE id = {ninja_id};";
                cnx.Open();
                cnx.Execute(query);
            }
        }

        public static void Banish(int id){
            using (IDbConnection cnx = Connection){
                string query = $"UPDATE ninjas SET dojo_id = null WHERE id = {id}";
                cnx.Open();
                cnx.Execute(query);
            }
        }
    }
}