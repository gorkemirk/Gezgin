using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class CardsController : BaseCRUDController<Card, int, CreateCardDto, CardUpdateDTO, CardInfoDTO>
    {
        public CardsController(ICardService service) : base(service)
        {
        }
    }
}
