using GChatAPI.Data;
using GChatAPI.Extensions;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GChatAPI.Graphql.Users
{
    [Authorize]
    [ExtendObjectType(Name = "Mutation")]
    public class UserMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUserPayload> AddUserAsync(
                AddUserInput input,
                [ScopedService] ApplicationDbContext dbContext,
                [Service] IHttpContextAccessor contextAccessor
            )
        {
            var httpContext = contextAccessor.HttpContext ?? throw new ArgumentNullException($"{contextAccessor.HttpContext} can't be null.");
            var userId = httpContext.User.Claims.Where(uc => uc.Type == "sub").FirstOrDefault().Value;

            var user = new User
            {
                Id = userId,
                Username = input.Username
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return new AddUserPayload(user);
        }
    }
}
