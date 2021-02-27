using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Data
{
    public class User
    {
#nullable disable
        [Key]
        public string Id { get; set; } // subject of user

#nullable enable
        [Required]
        [StringLength(200)]
        public string? Username { get; set; }

        //public ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();

    }
}
