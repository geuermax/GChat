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
    public class MessageByIdDataLoader : BatchDataLoader<int, Message>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public MessageByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<ApplicationDbContext> dbContextFactory): base(batchScheduler)
        {
            this._dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<int, Message>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext = this._dbContextFactory.CreateDbContext();

            return await dbContext.Messages
                .Where(m => keys.Contains(m.Id))
                .ToDictionaryAsync(m => m.Id, cancellationToken);
        }
    }
}
