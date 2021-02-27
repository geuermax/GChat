using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GChatAPI.Data.DataLoader
{
    public class UserByIdDataLoader : BatchDataLoader<string, User>
    {
        public readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public UserByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory): base(batchScheduler)
        {
            this._dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<string, User>> LoadBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext = this._dbContextFactory.CreateDbContext();

            return await dbContext.Users
                .Where(u => keys.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, cancellationToken);                
        }
    }
}
