using GChatAPI.Data;
using GChatAPI.Graphql.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Users
{
    public class AddUserPayload: Payload
    {
        public User? User { get; }

        public AddUserPayload(User user)
        {
            this.User = user;
        }

        public AddUserPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
