﻿using GChatAPI.Data;
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

namespace GChatAPI.Graphql.Users
{
    [Authorize]
    [ExtendObjectType(Name = "Query")]
    public class UserQueries
    {

        public async Task<User> GetUserAsync([Service]IHttpContextAccessor contextAccessor, UserByIdDataLoader userById, CancellationToken ct)
        {
            var httpContext = contextAccessor.HttpContext ?? throw new ArgumentNullException($"{nameof(contextAccessor.HttpContext)} can't be null.");

            var id = httpContext.User.Claims.Where(uc => uc.Type == "sub").FirstOrDefault();
            return await userById.LoadAsync(id.Value, ct);
        }
    }
}
