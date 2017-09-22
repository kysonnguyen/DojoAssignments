using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class Order : BaseEntity {
        [Key]
        public int id {get;set;}

        [Required]
        public int quantity {get;set;}
        
        public int product_id {get;set;}
        public int customer_id {get;set;}

        public DateTime created_at {get;set;}
        public Customer customer {get; set;}
        public Product product {get; set;}
    }
}