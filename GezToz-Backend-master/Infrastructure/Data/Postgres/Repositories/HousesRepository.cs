using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Infrastructure.Data.Postgres.Repositories;

public class HousesRepository : Repository<House, int>, IHousesRepository
{
    public HousesRepository(PostgresContext postgresContext) : base(postgresContext)
    {
    }

    public async Task AddAsync(House entity)
    {
        await PostgresContext.Set<House>().AddAsync(entity);
        await PostgresContext.SaveChangesAsync();
    }

    public Task AddRangeAsync(IEnumerable<House> entities)
    {
        throw new NotImplementedException();
    }

    public Task<House?> FirstOrDefaultAsync(Expression<Func<House, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<House>> GetAllAsync(Expression<Func<House, bool>>? filter = null)
    {
        var houses = PostgresContext.Set<House>();
        return filter == null
            ? await houses.ToListAsync()
            : await houses.Where(filter)
            .ToListAsync();
    }

    public Task<House?> GetAsync(Expression<Func<House, bool>> filter)
    {
        throw new NotImplementedException();
    }
    public Task<int> GetCountAsync(Expression<Func<House, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }
    public Task RemoveAsync(House entity)
    {
        throw new NotImplementedException();
    }
    public void RemoveRange(IEnumerable<House> entities)
    {
        throw new NotImplementedException();
    }

    public void UntrackEntity(House entity)
    {
        throw new NotImplementedException();
    }

    public void Update(House entity)
    {
        PostgresContext.Set<House>().Update(entity);
        PostgresContext.SaveChanges();
    }

    public void UpdateRange(IEnumerable<House> entities)
    {
        throw new NotImplementedException();
    }

    async Task<House> IRepository<House, int>.GetByIdAsync(int id)
    {
        return await PostgresContext.Set<House>().FindAsync(id);
    }

    public Task<IList<House>> GetByHouseIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}