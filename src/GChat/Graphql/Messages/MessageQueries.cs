using GChatAPI.Data;
using GChatAPI.Data.DataLoader;
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
    [ExtendObjectType(Name = "Query")]
    public class MessageQueries
    {
        
        public async Task<Message> GetMessageAsync(int id, [Service] IHttpContextAccessor contextAccessor, MessageByIdDataLoader messageById, CancellationToken ct)
        {
            var message = await messageById.LoadAsync(id, ct) ?? throw new Exception("No message found for id.");
            var httpContext = contextAccessor.HttpContext ?? throw new ArgumentNullException($"{nameof(contextAccessor.HttpContext)} can't be null.");
            var userId = httpContext.User.Claims.Where(uc => uc.Type == "sub").FirstOrDefault().Value;
            if (message.SenderId != userId)
            {
                throw new UnauthorizedAccessException("User is not allowed to retrive this message.");
            }

            return message;
        }

    }
}
