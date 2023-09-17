using Business.Models.Response;
using Business.Services.Base;
using Business.Services.Interface;
using Business.Utilities.Mapping.Interface;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   
    public class AdvertService : BaseService<Advert, int, AdvertInfoDto>, IAdvertService
    {
        //unitOfWork.Cars Olması gerekiyor
        public AdvertService(IUnitOfWork unitOfWork, IMapperHelper mapperHelper) : base(unitOfWork, unitOfWork.Advert, mapperHelper)
        {
        }
    }
}
