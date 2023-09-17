using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;
using Infrastructure.Data.Postgres.Entities;

namespace Infrastructure.Data.Postgres.Repositories.Interface
{
    public interface IHousesRepository : IRepository<House, int>
    {
        Task<IList<House>> GetByHouseIdAsync(int id);
    }
}
