using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using thewall.Models;
using Microsoft.AspNetCore.Http;

namespace thewall.Factories
{
    public class MessageFactory : IFactory<Message>
    {
        private static string connectionString;
        public MessageFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=thewall;SslMode=None";
        }
        
        internal static IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public static List<Message> GetAllMessage(){
            using(IDbConnection cnx = Connection)
            {
                cnx.Open();
                string query = "SELECT * FROM messages JOIN users ON messages.user_id WHERE messages.user_id = users.id ORDER BY messages.created_at DESC; SELECT * FROM comments JOIN users ON comments.user_id WHERE comments.user_id = users.id;";
                using (var multi = cnx.QueryMultiple(query, null))
                {
                    var messages = multi.Read<Message, User, Message>((message, user) => { message.user = user; return message; }).ToList();
                    var comments = multi.Read<Comment, User, Comment>((comment, user) => { comment.user = user; return comment; }).ToList();
                    List<Message> mescom = messages.GroupJoin(comments, 
                            message => message.id,
                            comment => comment.message_id,
                            (message, m_comment) =>
                            {
                                message.comments = m_comment.ToList();
                                return message;
                            }).ToList();
                    return mescom;
                }
            }
        }
        
        public static void Add(Message Info){
            using(IDbConnection cnx = Connection)
            {
                string query = "INSERT INTO messages (message, user_id, created_at, updated_at) VALUES (@message, @user_id, NOW(), NOW());";
                cnx.Open();
                cnx.Execute(query, Info);
            }
        }
    }


}