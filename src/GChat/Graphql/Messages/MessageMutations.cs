using GChatAPI.Data;
using GChatAPI.Data.DataLoader;
using GChatAPI.Extensions;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Messages
{
    [Authorize]
    [ExtendObjectType(Name = "Mutation")]
    public class MessageMutations
    {
        [UseApplicationDbContext]
        public async Task<SendMessagePayload> SendMessageAsync(
                SendMessageInput input,
                [ScopedService] ApplicationDbContext dbContext,
                [Service] IHttpContextAccessor contextAccessor,
                ChatByIdDataLoader chatById,
                UserByIdDataLoader userById,
                CancellationToken ct
            )
        {
            var httpContext = contextAccessor.HttpContext ?? throw new ArgumentNullException($"{nameof(contextAccessor.HttpContext)} can't be null.");
            var user = await userById.LoadAsync(httpContext.User.Claims.Where(uc => uc.Type == "sub").FirstOrDefault().Value ?? throw new Exception("No subject in token found."), ct) ?? throw new Exception("User not found.");
            var chat = await chatById.LoadAsync(input.ChatId, ct) ?? throw new Exception("No chat found.");

            var userChat = dbContext.UserChats.Where(uc => uc.ChatId == chat.Id && uc.UserId == user.Id).FirstOrDefault();

            if (userChat != null)
            {
                var message = new Message
                {
                    SenderId = user.Id,
                    ChatId = chat.Id,
                    Text = input.Text,
                    Timestamp = DateTime.Now
                };

                dbContext.Messages.Add(message);
                await dbContext.SaveChangesAsync();

                return new SendMessagePayload(message);
            } else
            {
                throw new Exception("User is not a participant of the chat.");
            }
        }
    }
}
