using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using thewall.Models;

namespace thewall.Factories
{
    public class CommentFactory : IFactory<Comment>
    {
        private static string connectionString;
        public CommentFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=thewall;SslMode=None";
        }
        internal static IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        
        public static void Add(Comment Info){
            using(IDbConnection cnx = Connection)
            {
                string query = "INSERT INTO comments (comment, user_id, message_id) VALUES (@comment, @user_id, @message_id);";
                cnx.Open();
                cnx.Execute(query, Info);
            }
        }
    }


}