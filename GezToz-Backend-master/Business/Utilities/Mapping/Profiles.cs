using Business.Models.Request.Create;
using Business.Models.Request.Functional;
using Business.Models.Request.Update;
using Business.Models.Response;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Utilities.Mapping;

public class Profiles : AutoMapper.Profile
{
    public Profiles()
    {
        //User
        CreateMap<RegisterDto, User>();
        CreateMap<User, UserProfileDto>();
        CreateMap<UserUpdateDTO, User>();


        //House 
        CreateMap<CreateHouseDto, House>();
        CreateMap<HouseUpdateDTO, House >();
        CreateMap<House, Models.Response.HouseİnfoDto>();        

        //Booking 
        CreateMap<CreateBookingDto, Booking>();
        CreateMap<BookingUpdateDTO, Booking >();
        CreateMap<Booking, Models.Response.BookingInfoDto>();

        //Cards
        CreateMap<CreateCardDto, Card>();
        CreateMap<CardUpdateDTO, Card>();
        CreateMap<Card, Models.Response.CardInfoDTO>();

        //Adverts
        CreateMap<CreateAdvertDto, Advert>();
        CreateMap<AdvertUpdateDTO, Advert>();
        CreateMap<Advert, Models.Response.AdvertInfoDto>();

        //Comments
        CreateMap<CreateCommentDto, Comment>();
        CreateMap<CommentUpdateDTO, Comment>();
        CreateMap<Comment, Models.Response.CommentInfoDto>();
    }
}