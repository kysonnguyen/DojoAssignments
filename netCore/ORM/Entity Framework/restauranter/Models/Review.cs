using System;
using System.ComponentModel.DataAnnotations;

namespace restauranter.Models
{
    public class Review
    {
        [Key]
        public int ReviewId {get;set;}

        [Required]
        public string reviewer {get;set;}

        [Required]
        public string restaurant {get;set;}

        [Required]
        [MinLength(10)]
        public string review {get;set;}

        [Required]
        public int stars {get;set;}

        [Required]
        public DateTime visitDate {get;set;}
        public DateTime created_at {get;set;}

        public DateTime updated_at {get;set;}

    }
}