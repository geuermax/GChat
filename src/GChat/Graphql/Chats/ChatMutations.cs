using GChatAPI.Data;
using GChatAPI.Data.DataLoader;
using GChatAPI.Extensions;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Chats
{
    [Authorize]
    [ExtendObjectType(Name = "Mutation")]
    public class ChatMutations
    {
        [UseApplicationDbContext]
        public async Task<AddChatPayload> AddChatAsync(
                AddChatInput input,
                [ScopedService] ApplicationDbContext dbContext,
                [Service] IHttpContextAccessor contextAccessor,
                ChatByIdDataLoader chatById,
                CancellationToken ct
            )
        {
            var httpContext = contextAccessor.HttpContext ?? throw new ArgumentNullException($"{nameof(contextAccessor.HttpContext)} can't be null.");
            var userId = httpContext.User.Claims.Where(uc => uc.Type == "sub").FirstOrDefault().Value;

            var userIds = input.UserIds ?? throw new ArgumentNullException($"{nameof(input.UserIds)} can't be null.");

            if (!userIds.Contains(userId))
            {
                userIds.Add(userId);
            }

            var chat = new Chat
            {
                Messages = new List<Message>()
            };

            
            // Check if there is an existing chat with all users
                // if so return the existing chat

            // Get all ids of chats where all users are inside            
            int[] chatIdsOfUsers = await dbContext.UserChats
                .Where(uc => userIds.Contains(uc.UserId))
                .GroupBy(uc => uc.ChatId, (g, r) => new
                {
                    ChatId = g,
                    Count = r.Count()
                })
                .Where(p => p.Count == userIds.Count)
                .Select(p => p.ChatId)
                .ToArrayAsync();
            
            if (chatIdsOfUsers != null && chatIdsOfUsers.Length > 0)
            {
                int[] existingChats = await dbContext.UserChats
                    .Where(uc => chatIdsOfUsers.Contains(uc.ChatId))
                    .GroupBy(uc => uc.ChatId, (g, r) => new
                    {
                        ChatId = g,
                        Count = r.Count()
                    })
                    .Where(p => p.Count == userIds.Count)
                    .Select(p => p.ChatId)
                    .ToArrayAsync();
                 

                if (existingChats != null && existingChats.Length > 0)
                {
                    return new AddChatPayload(await chatById.LoadAsync(existingChats[0], ct));
                }
            }


            // no existing chat found with all users so a new one will be created
            dbContext.Chats.Add(chat);
            var chatId = chat.Id;
            List<UserChat> userChats = new List<UserChat>();

            foreach(string uId in userIds)
            {
                userChats.Add(new UserChat
                {
                    ChatId = chatId,
                    UserId = uId
                });
            }

            chat.UserChats = userChats;

            await dbContext.SaveChangesAsync();

            return new AddChatPayload(chat);
        }

        [UseApplicationDbContext]
        public async Task<AddParticipantPayload> GetAddParticipantAsync(
                AddParticipantInput input,
                [ScopedService] ApplicationDbContext dbContext,
                [Service] IHttpContextAccessor contextAccessor,
                UserByIdDataLoader userById,
                ChatByIdDataLoader chatById,
                CancellationToken ct
            )
        {
            var user = await userById.LoadAsync(input.UserId, ct) ?? throw new Exception("User not found.");
            var chat = await chatById.LoadAsync(input.ChatId, ct) ?? throw new Exception("Chat not found.");

            // Todo: Check if user is allowed to add participants --> add something like a groupadmin

            var userChat = new UserChat
            {
                UserId = user.Id,
                ChatId = chat.Id
            };

            chat.UserChats.Add(userChat);

            await dbContext.SaveChangesAsync();

            return new AddParticipantPayload(chat);
        }
    }
}
