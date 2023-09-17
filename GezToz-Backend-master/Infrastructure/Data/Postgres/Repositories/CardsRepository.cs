using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Repositories
{
    public class CardsRepository : Repository<Card, int>, ICardsRepository
    {
        public CardsRepository(PostgresContext postgresContext) : base(postgresContext)
        {

        }

        public async Task AddAsync(Card entity)
        {
            await PostgresContext.Set<Card>().AddAsync(entity);
            await PostgresContext.SaveChangesAsync();
        }

        public Task AddRangeAsync(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Card?> FirstOrDefaultAsync(Expression<Func<Card, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Card>> GetAllAsync(Expression<Func<Card, bool>>? filter = null)
        {
            var Cards = PostgresContext.Set<Card>();
            return filter == null
                ? await Cards.ToListAsync()
                : await Cards.Where(filter).ToListAsync();
        }

        public Task<Card?> GetAsync(Expression<Func<Card, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Card>> GetByCarsIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Card>> GetByContactIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync(Expression<Func<Card, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Card entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }

        public void UntrackEntity(Card entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Card entity)
        {
            PostgresContext.Set<Card>().Update(entity);
            PostgresContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<Card> entities)
        {
            throw new NotImplementedException();
        }

        async Task<Card> IRepository<Card, int>.GetByIdAsync(int id)
        {
            return await PostgresContext.Set<Card>().FindAsync(id);
        }
    }
}
