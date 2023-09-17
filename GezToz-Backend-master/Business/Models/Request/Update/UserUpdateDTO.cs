using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Request.Update;

public class UserUpdateDTO
{
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    
    // public string Password { get; set; } = default!;

    public string FullName { get; set; } = default!;
    public UserType UserType { get; set; }
}