using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using thewall.Models;
using Microsoft.Extensions.Options;

namespace thewall.Factories
{
    public class UserFactory : IFactory<User>
    {
        private static string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=thewall;SslMode=None";
        }
        internal static IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public static void Add(User Info)
        {
            using (IDbConnection cnx = Connection) {
                string query = "INSERT INTO users (FirstName, LastName, Email, Password, created_at, updated_at) VALUES (@FirstName, @LastName, @Email, @Password, NOW(), NOW());";
                cnx.Open();
                cnx.Execute(query, Info);
            }
        }

        public static User GetLatestUser()
        {
            using(IDbConnection cnx = Connection){
                string query = "SELECT * FROM users ORDER BY id DESC LIMIT 1";
                cnx.Open();
                return cnx.QuerySingleOrDefault<User>(query);
            }
        }

        public static User LogInUser(string Email, string Password)
        {
            using(IDbConnection cnx = Connection)
            {
                string query = $"SELECT * FROM users WHERE email = '{Email}' AND pw_hash = '{Password}'";
                cnx.Open();
                return cnx.QuerySingleOrDefault<User>(query);
            }
        }

        public static User GetUserByEmail(string Email)
        {
            using(IDbConnection cnx = Connection)
            {
                string query = $"SELECT * FROM users WHERE email = '{Email}'";
                cnx.Open();
                return cnx.QuerySingleOrDefault<User>(query);
            }
        }

        public static User GetUserById(int id){
             using(IDbConnection cnx = Connection)
            {
                string query = $"SELECT * FROM users WHERE id = '{id}'";
                cnx.Open();
                return cnx.QuerySingleOrDefault<User>(query);
            }
        }
        
    }
}