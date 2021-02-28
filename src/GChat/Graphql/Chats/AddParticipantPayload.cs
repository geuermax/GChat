using GChatAPI.Data;
using GChatAPI.Graphql.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Chats
{
    public class AddParticipantPayload: Payload
    {
        public Chat? Chat { get; }

        public AddParticipantPayload(Chat chat)
        {
            this.Chat = chat;
        }

        public AddParticipantPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
