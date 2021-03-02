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
    public class UserType: ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                .Field(u => u.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(u => u.UserChats)
                .ResolveWith<UserResolvers>(ur => ur.GetChatsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("chats");
        }




        private class UserResolvers
        {
            public async Task<IEnumerable<Chat>> GetChatsAsync(
                    User user,
                    [ScopedService] ApplicationDbContext dbContext,
                    ChatByIdDataLoader chatById,
                    CancellationToken ct
                )
            {
                int[] chatIds = await dbContext.Users
                    .Where(u => u.Id == user.Id)
                    .Include(u => u.UserChats)
                    .SelectMany(u => u.UserChats.Select(uc => uc.ChatId))
                    .ToArrayAsync();

                return await chatById.LoadAsync(chatIds, ct);
            }
        }
    }
}
