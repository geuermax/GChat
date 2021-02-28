using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Chats
{
    public class AddParticipantInput
    {
        public int ChatId { get; set; }
        public string UserId { get; set; }

        public AddParticipantInput(int chatId, string userId)
        {
            this.ChatId = chatId;
            this.UserId = userId;
        }
    }
}
