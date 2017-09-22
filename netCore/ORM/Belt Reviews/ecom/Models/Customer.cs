using System;
using System.ComponentModel.DataAnnotations;

namespace ecom.Models
{
    public abstract class BaseEntity {}
    public class Customer: BaseEntity
    {
        [Key]
        public int id {get;set;}

        [Required]
        public string name {get;set;}

        public DateTime created_at {get;set;}
    }  

}