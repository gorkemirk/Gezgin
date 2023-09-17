using Infrastructure.Data.Postgres.Repositories.Interface;

namespace Infrastructure.Data.Postgres;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IUserTokenRepository UserTokens { get; }
    IBookingRepository Booking { get; }
    ICardsRepository Cards { get; }
    IAdvertRepository Advert { get; }
    ICommentsRepository Comments { get; }
    IHousesRepository Houses { get; }
    Task<int> CommitAsync();
}