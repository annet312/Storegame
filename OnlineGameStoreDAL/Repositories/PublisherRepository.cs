using Microsoft.EntityFrameworkCore;
using OnlineGameStoreDAL.Context;
using OnlineGameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OnlineGameStoreDAL.Repositories
{
    internal class PublisherRepository
    {
        private readonly StoreDbContext dbContext;

        public PublisherRepository(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public IEnumerable<Publisher> Get(Expression<Func<Publisher, bool>> predicate)
        {
            IEnumerable<Publisher> publishers = dbContext.Set<Publisher>()
                                                .Where(predicate)
                                                .Include(p => p.Games)
                                                    .ThenInclude(g => g.GameGenres).ThenInclude(gg => gg.Genre)
                                                .AsEnumerable();
            return publishers;
        }

        public IEnumerable<Publisher> GetAll()
        {
            IEnumerable<Publisher> publishers = dbContext.Set<Publisher>()
                                                .Include(p => p.Games)
                                                    .ThenInclude(g => g.GameGenres).ThenInclude(gg => gg.Genre)
                                                .AsEnumerable();
            return publishers;
        }

        public void Update(Publisher publisher)
        {
            dbContext.Set<Publisher>().Update(publisher); ;
        }
    }
}
