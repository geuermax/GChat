using GChatAPI.Data;
using GChatAPI.Data.DataLoader;
using GChatAPI.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GChatAPI.Types
{
    public class ChatType: ObjectType<Chat>
    {

        protected override void Configure(IObjectTypeDescriptor<Chat> descriptor)
        {
            descriptor.Field(c => c.UserChats)
                .ResolveWith<ChatResolvers>(cr => cr.GetUsersAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("participants");

            descriptor.Field(c => c.Messages)
                .ResolveWith<ChatResolvers>(cr => cr.GetMessagesAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>();                
        }


        private class ChatResolvers
        {
            public async Task<IEnumerable<User>> GetUsersAsync(
                    Chat chat,
                    [ScopedService] ApplicationDbContext dbContext,
                    UserByIdDataLoader userById,
                    CancellationToken ct
                )
            {
                string[] userIds = await dbContext.Chats
                    .Where(c => c.Id == chat.Id)
                    .Include(c => c.UserChats)
                    .SelectMany(c => c.UserChats.Select(u => u.UserId))
                    .ToArrayAsync();

                return await userById.LoadAsync(userIds, ct);
            }


            public async Task<IEnumerable<Message>> GetMessagesAsync(
                    Chat chat,
                    [ScopedService] ApplicationDbContext dbContext,
                    MessageByIdDataLoader messageById,
                    CancellationToken ct
                )
            {
                int[] messageIds = await dbContext.Messages
                    .Where(m => m.ChatId == chat.Id)
                    .Select(m => m.Id)
                    .ToArrayAsync();

                return await messageById.LoadAsync(messageIds, ct);
            }
        }

    }
}
