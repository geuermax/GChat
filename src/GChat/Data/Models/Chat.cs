using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Data
{
    public class Chat
    {
        public int Id { get; set; }
        //public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<UserChat> UserChats { get; set; } = new List<UserChat>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
