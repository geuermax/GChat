using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Users
{
    public class AddUserInput
    {
        public string Username { get; set; }

        public AddUserInput(string username)
        {
            this.Username = username;
        }
    }
}
