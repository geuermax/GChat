using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Messages
{
    public class SendMessageInput
    {
        public string Text { get; set; }
        public int ChatId { get; set; }

        public SendMessageInput(string text)
        {
            this.Text = text;
        }
    }
}
