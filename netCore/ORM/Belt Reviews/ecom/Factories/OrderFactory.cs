using System.Data;
using Microsoft.Extensions.Options;
using ecom.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace ecom.Factory
{
    public class OrderFactory : IFactory<Order>
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;
        public OrderFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }

        public void Add(Order newOrder)
        {
            using(IDbConnection cnx = Connection){
                string query = "INSERT INTO orders (customer_id, product_id, quantity, created_at) VALUES (@customer_id, @product_id, @quantity, NOW());";
                cnx.Open();
                cnx.Execute(query, newOrder);
            }
        }

        public List<Order> GetAllOrders(){
            using(IDbConnection cnx = Connection){
                string query = "SELECT * FROM orders JOIN customers ON customers.id = orders.customer_id JOIN products ON products.id = orders.product_id ORDER BY orders.created_at DESC;";
                cnx.Open();
                return cnx.Query<Order,Customer,Product,Order>(query, (o,c,p) => {o.customer = c; o.product = p; return o;}).ToList();
            }
        }
        
        
    }
}