using System;

namespace Core.Models.Users;

public abstract class UserBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public required Address Address { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} Telefonnr.: {Phone} E-post: {Email} Adress: {Address}";
    }
}
