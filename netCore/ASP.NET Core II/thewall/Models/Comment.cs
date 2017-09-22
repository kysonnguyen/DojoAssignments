using System;
using System.ComponentModel.DataAnnotations;

namespace thewall.Models
{
    public class Comment : BaseEntity
    {
        [Key]
        public int Id {get; set;}
        
        [Required]
        [MinLength(1, ErrorMessage = "Comment cannot be empty")]
        public string comment { get; set; }
        
        public int user_id { get; set; }
        public int message_id {get;set;}
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; } 
        public User user { get; set; }
        public Message message { get; set; }
    }
}