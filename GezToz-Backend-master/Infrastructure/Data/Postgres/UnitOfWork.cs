using Core.Utilities;
using Infrastructure.Data.Postgres.Entities.Base.Interface;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgresContext _postgresContext;

    private UserRepository? _userRepository;
    private UserTokenRepository? _userTokenRepository;
    private BookingRepository? _bookingRepository;
    private CardsRepository? _cardsRepository;
    private CommentRepository? _commentsRepository;
    private HousesRepository? _housesRepository;
    private AdvertRepository? _advertRepository;

    public UnitOfWork(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_postgresContext);
    public IUserTokenRepository UserTokens => _userTokenRepository ??= new UserTokenRepository(_postgresContext);

    public IHousesRepository Houses => _housesRepository ??= new HousesRepository(_postgresContext);
    public IBookingRepository Booking => _bookingRepository ??= new BookingRepository(_postgresContext);
    public ICommentsRepository Comments => _commentsRepository ??= new CommentRepository(_postgresContext);
    public ICardsRepository Cards => _cardsRepository ??= new CardsRepository(_postgresContext);
    public IAdvertRepository Advert => _advertRepository ??= new AdvertRepository(_postgresContext);

    public async Task<int> CommitAsync()
    {
        var updatedEntities = _postgresContext.ChangeTracker.Entries<IEntity>()
            .Where(e => e.State == EntityState.Modified)
            .Select(e => e.Entity);

        foreach (var updatedEntity in updatedEntities)
        {
            updatedEntity.UpdatedAt = DateTime.UtcNow.ToTimeZone();
        }

        var result = await _postgresContext.SaveChangesAsync();

        return result;
    }

    public void Dispose()
    {
        _postgresContext.Dispose();
    }
}