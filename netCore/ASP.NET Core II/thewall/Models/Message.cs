using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace thewall.Models
{
    public class Message : BaseEntity
    {
        [Key]
        public int id {get; set;}
        
        [Required]
        [MinLength(1, ErrorMessage = "Message cannot be empty")]
        public string message { get; set; }
        public int user_id {get;set;}
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public User user {get;set;}
        public List<Comment> comments {get;set;}
    }
}