using System.Data;
using Microsoft.Extensions.Options;
using ecom.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace ecom.Factory
{
    public class CustomerFactory : IFactory<Customer>
    {
        private string ConnectionString;
        public CustomerFactory(IOptions<MySqlOptions> config)
        {
            ConnectionString = config.Value.ConnectionString;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(ConnectionString);
            }
        }

        public void Add(Customer newCustomer)
        {
            using(IDbConnection cnx = Connection){
                string query = "INSERT INTO customers (name, created_at) VALUES (@name, NOW());";
                cnx.Open();
                cnx.Execute(query, newCustomer);
            }
        }

        public List<Customer> GetAllCustomers(){
            using(IDbConnection cnx = Connection){
                string query = "SELECT * FROM customers;";
                cnx.Open();
                return cnx.Query<Customer>(query).ToList();
            }
        }
        
        public bool GetCustomerByName(string name)
        {
            using(IDbConnection cnx = Connection){
                string query = $"SELECT * FROM customers WHERE name = {name};";
                cnx.Open();
                return cnx.Query<bool>(query).SingleOrDefault();
            }
        }
        public void Remove(int id)
        {
            using(IDbConnection cnx = Connection){
                string query = $"DELETE FROM orders WHERE customer_id = {id}; DELETE FROM customers WHERE id = {id};";
                cnx.Open();
                cnx.Execute(query);
            }
        }
    }
}