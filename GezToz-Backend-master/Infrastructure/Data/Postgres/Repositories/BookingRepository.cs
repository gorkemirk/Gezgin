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

namespace Infrastructure.Data.Postgres.Repositories;

public class BookingRepository : Repository<Booking, int>, IBookingRepository
{
    public BookingRepository(PostgresContext postgresContext) : base(postgresContext)
    {

    }


    public async Task<IList<Booking>> GetAllAsync(Expression<Func<Booking, bool>>? filter = null)
    {
        var Cards = PostgresContext.Set<Booking>();
        return filter == null
            ? await Cards.ToListAsync()
            : await Cards.Where(filter).ToListAsync();
    }

    public Task<IList<Booking>> GetByContactIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    public void Update(Booking entity)
    {
        PostgresContext.Set<Booking>().Update(entity);
        PostgresContext.SaveChanges();
    }
    async Task<Booking> IRepository<Booking, int>.GetByIdAsync(int id)
    {
        return await PostgresContext.Set<Booking>().FindAsync(id);
    }
}
