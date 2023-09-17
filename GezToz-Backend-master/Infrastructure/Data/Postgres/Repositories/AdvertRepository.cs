using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories.Base;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Infrastructure.Data.Postgres.Repositories;

public class AdvertRepository : Repository<Advert, int>,IAdvertRepository
{
    public AdvertRepository(PostgresContext postgresContext) : base(postgresContext)
    {
    }

    public async Task<IList<Advert>> GetAllAsync(Expression<Func<Advert, bool>>? filter = null)
    {
        var adverts = PostgresContext.Set<Advert>();
        return filter == null
            ? await adverts.ToListAsync()
            : await adverts.Where(filter)
            .ToListAsync();
    }

    public Task<IList<Advert>> GetByContactIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
