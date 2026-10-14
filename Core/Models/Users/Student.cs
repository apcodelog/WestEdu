using System;
using Core.Interfaces;

namespace Core.Models.Users;

public class Student : UserBase
{
    public required string SSN { get; set; } // Social Security Number

    public override string ToString()
    {
        return base.ToString() + $" Personnr.: {SSN}";
    }
}
