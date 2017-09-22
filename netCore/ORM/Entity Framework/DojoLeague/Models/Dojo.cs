using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Dojo : BaseEntity
    {
        [Key]
        public int DojoId {get;set;}

        [Required]
        public string name {get;set;}

        [Required]
        public string location {get;set;}

        [Required]
        public string additional_information {get;set;}

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Ninja> ninjas {get;set;}
    }
}