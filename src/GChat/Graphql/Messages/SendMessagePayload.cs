using GChatAPI.Data;
using GChatAPI.Graphql.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Messages
{
    public class SendMessagePayload: Payload
    {
        public Message? Message { get; }

        public SendMessagePayload(Message message)
        {
            this.Message = message;
        }

        public SendMessagePayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
