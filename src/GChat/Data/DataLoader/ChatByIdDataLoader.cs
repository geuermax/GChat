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
    public class ChatByIdDataLoader : BatchDataLoader<int, Chat>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;


        public ChatByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory): base(batchScheduler)
        {
            this._dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<int, Chat>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext = this._dbContextFactory.CreateDbContext();

            return await dbContext.Chats
                .Where(c => keys.Contains(c.Id))
                .ToDictionaryAsync(c => c.Id, cancellationToken);
        }
    }
}
