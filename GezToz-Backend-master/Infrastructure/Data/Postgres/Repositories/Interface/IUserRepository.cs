﻿using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Repositories.Base.Interface;

namespace Infrastructure.Data.Postgres.Repositories.Interface;

public interface IUserRepository : IRepository<User, int>
{
    Task<IList<User>> GetByContactIdAsync(int id);
}