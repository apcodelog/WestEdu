using System;

namespace Core.Models.Users;

public class SchoolAdmin : Student
{
    public DateTime HiringDate { get; set; }

    public override void SetUserInfo()
    {
        base.SetUserInfo();
        HiringDate = ConsoleInputHelper.GetDate("Skriv anställningsdatum");
    }

    public override string ToString()
    {
        return base.ToString() + $" Anställningsdatum: {HiringDate}";
    }
}
