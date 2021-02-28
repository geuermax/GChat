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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Chats
{
    [Authorize]
    [ExtendObjectType(Name = "Query")]
    public class ChatQueries
    {

        [UseApplicationDbContext]
        public async Task<IEnumerable<Chat>> GetChatsAsync(
                [Service] IHttpContextAccessor contextAccessor, 
                [ScopedService] ApplicationDbContext dbContext, 
                ChatByIdDataLoader chatById, 
                CancellationToken ct
            )
        {
            var httpContext = contextAccessor.HttpContext ?? throw new ArgumentNullException($"{nameof(contextAccessor.HttpContext)} cant't be null.");            
            var userId = httpContext.User.Claims.Where(uc => uc.Type == "sub").FirstOrDefault().Value;
            int[] chatIds = await dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserChats)
                .SelectMany(u => u.UserChats.Select(uc => uc.ChatId))
                .ToArrayAsync();

            return await chatById.LoadAsync(chatIds, ct);
        }

    }
}
