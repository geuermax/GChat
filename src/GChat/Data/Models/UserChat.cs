using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Data
{
    public class UserChat
    {
#nullable disable
        public string UserId { get; set; }
#nullable enable
        public User? User { get; set; }
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }


    }
}
