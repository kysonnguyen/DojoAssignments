using System;
using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models{
    public class Ninja : BaseEntity
    {
        [Key]
        public int id {get;set;}

        [Required]
        public string name {get;set;}

        [Required]
        public int level {get;set;}

        public string description {get;set;}

        public int dojo_id {get;set;}

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public Dojo dojo {get;set;}
    }
}