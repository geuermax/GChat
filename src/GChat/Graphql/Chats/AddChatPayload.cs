using GChatAPI.Data;
using GChatAPI.Graphql.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Chats
{
    public class AddChatPayload: Payload
    {
        public Chat? Chat { get; }

        public AddChatPayload(Chat chat)
        {
            this.Chat = chat;
        }

        public AddChatPayload(IReadOnlyList<UserError> errors) : base (errors) { }
    }
}
