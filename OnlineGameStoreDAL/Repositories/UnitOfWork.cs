using OnlineGameStoreDAL.Context;
using OnlineGameStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameStoreDAL.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext dbContext;

        public UnitOfWork(StoreDbContext context)
        {
            this.dbContext = context;
        }

        private GameRepository games;
        private PublisherRepository publishers;

        public GameRepository Students
        {
            get
            {
                if (games == null)
                {
                    games = new GameRepository(dbContext);
                }
                return games;
            }
        }

        public PublisherRepository Publisher
        {
            get
            {
                if (publishers == null)
                {
                    publishers = new PublisherRepository(dbContext);
                }
                return publishers;
            }
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
