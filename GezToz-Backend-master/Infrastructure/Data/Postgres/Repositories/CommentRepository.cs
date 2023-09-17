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

public class CommentRepository : Repository<Comment, int>, ICommentsRepository
{
    public CommentRepository(PostgresContext postgresContext) : base(postgresContext)
    {

    }
    public async Task<IList<Comment>> GetAllAsync(Expression<Func<Comment, bool>>? filter = null)
    {
        var Cards = PostgresContext.Set<Comment>();
        return filter == null
            ? await Cards.ToListAsync()
            : await Cards.Where(filter).ToListAsync();
    }
    public Task<IList<Comment>> GetByContactIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Comment entity)
    {
        PostgresContext.Set<Comment>().Update(entity);
        PostgresContext.SaveChanges();
    }
    async Task<Comment> IRepository<Comment, int>.GetByIdAsync(int id)
    {
        return await PostgresContext.Set<Comment>().FindAsync(id);
    }

    public async Task AddAsync(Comment entity)
    {
        await PostgresContext.Set<Comment>().AddAsync(entity);
        await PostgresContext.SaveChangesAsync();
    }

}


