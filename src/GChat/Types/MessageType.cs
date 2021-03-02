using GChatAPI.Data;
using GChatAPI.Data.DataLoader;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GChatAPI.Types
{
    public class MessageType : ObjectType<Message>
    {

        protected override void Configure(IObjectTypeDescriptor<Message> descriptor)
        {
            descriptor
                .Field(m => m.Id)
                .Type<NonNullType<IdType>>();

            // resolve sender
            descriptor
                .Field(m => m.Sender)
                .ResolveWith<MessageResolvers>(mr => mr.GetUserAsync(default!, default!, default));

            descriptor
                .Field(m => m.SenderId)
                .Ignore();
                //.ID(nameof(User));

            // resolve chat
            descriptor
                .Field(m => m.Chat)
                .ResolveWith<MessageResolvers>(mr => mr.GetChatAsync(default!, default! , default));

            descriptor
                .Field(m => m.ChatId)
                .Ignore();
                //.ID(nameof(Chat));
        }


        private class MessageResolvers
        {
            public async Task<User> GetUserAsync(
                    Message message,
                    UserByIdDataLoader userById,
                    CancellationToken ct
                )
            {                
                return await userById.LoadAsync(message.SenderId ?? throw new Exception($"{nameof(message.SenderId)} can't be null."), ct);
            }  


            public async Task<Chat> GetChatAsync(
                    Message message,
                    ChatByIdDataLoader chatById,
                    CancellationToken ct
                )
            {
                return await chatById.LoadAsync(message.ChatId, ct);
            }
        }
    }
}
