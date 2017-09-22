using System;
using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class Trail : BaseEntity
    {
        [Key]
        public long id {get;set;}

        [Required]
        [MinLength(3)]
        public string name {get;set;}

        [Required]
        [MinLength(10)]
        public string description {get;set;}

        [Required]
        public double length {get;set;}

        [Required]
        public float elevation_change {get;set;}
        public string longitude {get;set;}
        public string latitude {get;set;}
        
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;} 

    }
}