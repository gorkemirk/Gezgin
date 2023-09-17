using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities;

public class User : Entity<int>
{
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!; 
    public string FullName { get; set; } = default!;
    public byte[] PasswordSalt { get; set; } = default!;
    public byte[] PasswordHash { get; set; } = default!;
    public UserType UserType { get; set; }

    public ICollection<House> House { get; set; } 
    public ICollection<Comment> Comment { get; set; } 
    public ICollection<Card> Card { get; set; } 
    public ICollection<Advert> Advert { get; set; } 
    public ICollection<Booking> Booking { get; set; } 
}

public enum UserType
{
    Admin,
    User,
}