using System;

namespace Core.Models.Users;

public class SchoolAdmin : Student
{
    public required DateTime HiringDate { get; set; }

    public override string ToString()
    {
        return base.ToString() + $" Anställningsdatum: {HiringDate}";
    }
}
