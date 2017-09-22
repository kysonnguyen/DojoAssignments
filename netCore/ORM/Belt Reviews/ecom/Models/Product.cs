using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public class Product: BaseEntity
    {
        [Key]
        public int id {get;set;}

        [Required]
        [MinLength(2, ErrorMessage = "Item name must has at least 2 charcters")]
        public string name {get;set;}

        [Required]
        public string imgUrl {get;set;}
        
        [Required]
        public string description {get;set;}

        [Required]
        public int quantity {get;set;}

        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}
    }  

}