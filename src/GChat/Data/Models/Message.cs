using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Data
{
    public class Message
    {
        public int Id { get; set; }

        [Required]        
        public string? Text { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public int ChatId { get; set; }
        public Chat? Chat { get; set; }

        public int SenderId { get; set; }
        public User? Sender { get; set; }
    }
}
