using Microsoft.EntityFrameworkCore;
using OnlineGameStoreDAL.Context;
using OnlineGameStoreDAL.Entities;
using OnlineGameStoreDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameStoreDAL.Repositories
{
    internal class GameRepository : IRepository<Game>
    {
        private readonly StoreDbContext dbContext;

        public GameRepository (StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public IEnumerable<Game> Get(Expression<Func<Game, bool>> predicate)
        //{
        //    IEnumerable<Game> games = dbContext.Set<Game>().Where(predicate)
        //                                   .Include(g => g.Publisher)
        //                                   .Include(g => g.GameGenres).ThenInclude(gg => gg.Genre)
        //                                   .AsEnumerable();
        //    return games;
        //}

        //public IEnumerable<Game> GetAll()
        //{
        //    IEnumerable<Game> games = dbContext.Set<Game>()
        //                                   .Include(g => g.Publisher)
        //                                   .Include(g => g.GameGenres).ThenInclude(gg => gg.Genre).AsEnumerable();
        //    return games;
        //}

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            List<Game> games = await dbContext.Set<Game>()
                                           .Include(g => g.Publisher)
                                           .Include(g => g.GameGenres).ThenInclude(gg => gg.Genre)
                                           .ToListAsync();
            return games;
        }

        public async Task<IEnumerable<Game>> GetAsync(Expression<Func<Game, bool>> predicate)
        {
            List<Game> games = await dbContext.Set<Game>().Where(predicate)
                                           .Include(g => g.Publisher)
                                           .Include(g => g.GameGenres).ThenInclude(gg => gg.Genre)
                                           .ToListAsync();
            return games;
        }

        public void Update(Game game)
        {
            dbContext.Set<Game>().Update(game); ;
        }

        public void Add(Game game)
        {
            dbContext.Set<Game>().Add(game);
        }

        public void Delete(Game game)
        {
            //Game existing = dbContext.Set<Game>().Find(id);
            if (game != null) dbContext.Set<Game>().Remove(game);
        }
    }
}
