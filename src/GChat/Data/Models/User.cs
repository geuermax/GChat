using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Data
{
    public class User
    {        
        public string Id { get; set; } // subject of user
        
        [Required]
        public string Username { get; set; }

        public ICollection<Chat> Chats { get; set; }

    }
}
