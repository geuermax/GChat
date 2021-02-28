using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Chats
{
    public class AddChatInput
    {
        public ICollection<string> UserIds { get; }

        public AddChatInput(ICollection<string> userIds)
        {
            this.UserIds = userIds;
        }

    }
}
