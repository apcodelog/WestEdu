using System;
using Core.Interfaces;

namespace Core.Models.Users;

public class Student : UserBase
{
    public string SSN { get; set; } = ""; // Social Security Number

    public override void SetUserInfo()
    {
        base.SetUserInfo();
        SSN = ConsoleInputHelper.GetString("Skriv personnr.");
    }

    public override string ToString()
    {
        return base.ToString() + $" Personnr.: {SSN}";
    }
}
