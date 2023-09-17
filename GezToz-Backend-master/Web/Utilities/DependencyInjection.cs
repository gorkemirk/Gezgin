using Business.Services;
using Business.Services.Interface;
using Business.Utilities.Mapping;
using Business.Utilities.Mapping.Interface;
using Business.Utilities.Security.Auth.Jwt;
using Business.Utilities.Security.Auth.Jwt.Interface;
using Business.Utilities.Validation;
using Business.Utilities.Validation.Interface;
using Core.Utilities.Mail;
using Infrastructure.Data.Postgres;

namespace Web.Utilities;

public static class DependencyInjection
{
    public static void AddMyScoped(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IClaimHelper, ClaimHelper>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IHouseService, HouseService>();
        serviceCollection.AddScoped<IBookingService, BookingService>();
        serviceCollection.AddScoped<ICommentService, CommentService>();
        serviceCollection.AddScoped<ICardService, CardService>();
        serviceCollection.AddScoped<IAdvertService, AdvertService>();
        
    }

    public static void AddMySingleton(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        serviceCollection.AddSingleton<IMapperHelper, MapperHelper>();
        serviceCollection.AddSingleton<IValidationHelper, ValidationHelper>();
        serviceCollection.AddSingleton<IJwtTokenHelper, JwtTokenHelper>();
        serviceCollection.AddSingleton<IHashingHelper, HashingHelper>();
        serviceCollection.AddSingleton<IMailHelper, MailHelper>();
    }

    public static void AddMyTransient(this IServiceCollection serviceCollection)
    {
    }
}