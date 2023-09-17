using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Repositories.Interface
{
    public interface ICommentsRepository : IRepository<Comment, int>
    {
        Task<IList<Comment>> GetByContactIdAsync(int id);

    }
}
