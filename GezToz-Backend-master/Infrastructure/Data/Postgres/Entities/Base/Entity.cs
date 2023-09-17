using Core.Utilities;
using Infrastructure.Data.Postgres.Entities.Base.Interface;

namespace Infrastructure.Data.Postgres.Entities.Base;

public abstract class Entity<T> : IEntity
{
    public T Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

    protected Entity()
    {
        CreatedAt = DateTime.UtcNow.ToTimeZone();
        IsDeleted = false;
    }
}