using System;

namespace Core.Models.Users;

public abstract class UserBase
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string SSN { get; set; } // Social Security Number
    public Address Address { get; set; }
}
