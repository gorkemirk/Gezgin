using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Business.Services.Base.Interface;
using Business.Services.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class BookingController : BaseCRUDController<Booking, int, CreateBookingDto, BookingUpdateDTO, BookingInfoDto>
    {
        public BookingController(IBookingService service) : base(service)
        {
        }
    }
}


