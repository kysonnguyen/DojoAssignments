using System.Data;
using Microsoft.Extensions.Options;
using ecom.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace ecom.Factory
{
    public class ProductFactory : IFactory<Product>
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;
        public ProductFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }

        public void Add(Product newProduct)
        {
            using(IDbConnection cnx = Connection){
                string query = "INSERT INTO products (name, imgUrl, description, quantity, created_at, updated_at) VALUES (@name, @imgUrl, @description, @quantity, NOW(), NOW());";
                cnx.Open();
                cnx.Execute(query, newProduct);
            }
        }

        public List<Product> GetAllProducts(){
            using(IDbConnection cnx = Connection){
                string query = "SELECT * FROM products;";
                cnx.Open();
                return cnx.Query<Product>(query).ToList();
            }
        }
        
        public int GetCurrentQuantity(int id)
        {
            using(IDbConnection cnx = Connection){
                string query = $"SELECT quantity FROM products WHERE id = {id};";
                cnx.Open();
                return cnx.Query<int>(query).SingleOrDefault();
            }
        }
        public void UpdateQuanity(int id, int orderQuantity)
        {
            using(IDbConnection cnx = Connection){
                string query = $"UPDATE products SET quantity = quantity - {orderQuantity} WHERE id = {id};";
                cnx.Open();
                cnx.Execute(query);
            }
        }
    }
}