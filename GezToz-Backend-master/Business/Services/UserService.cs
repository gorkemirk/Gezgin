using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Business.Utilities.Mapping.Interface;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Services;

public class UserService : BaseService<User, int, UserProfileDto>, IUserService
{
    public UserService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper) : base(unitOfWork, unitOfWork.Users, mapperHelper)
    {
    }
}