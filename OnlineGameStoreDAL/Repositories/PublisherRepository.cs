using Microsoft.EntityFrameworkCore;
using OnlineGameStoreDAL.Context;
using OnlineGameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameStoreDAL.Repositories
{
    internal class PublisherRepository
    {
        private readonly StoreDbContext dbContext;

        public PublisherRepository(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Publisher>> GetAsync(Expression<Func<Publisher, bool>> predicate)
        {
            List<Publisher> publishers = await dbContext.Set<Publisher>()
                                                .Where(predicate)
                                                .Include(p => p.Games)
                                                    .ThenInclude(g => g.GameGenres).ThenInclude(gg => gg.Genre)
                                                .ToListAsync();
            return publishers;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            IEnumerable<Publisher> publishers = await dbContext.Set<Publisher>()
                                                .Include(p => p.Games)
                                                    .ThenInclude(g => g.GameGenres).ThenInclude(gg => gg.Genre)
                                                .ToListAsync();
            return publishers;
        }

        public void Update(Publisher publisher)
        {
            dbContext.Set<Publisher>().Update(publisher); ;
        }

        public void Add(Publisher publisher)
        {
            dbContext.Set<Publisher>().Add(publisher);
        }

        public void Delete(Publisher publisher)
        {
            //Game existing = dbContext.Set<Publisher>().Find(id);
            if (publisher != null) dbContext.Set<Publisher>().Remove(publisher);
        }
    }
}
