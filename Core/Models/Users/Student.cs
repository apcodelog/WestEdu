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

    public override List<string> GetInfoCells()
    {
        var cells = base.GetInfoCells();
        cells.Add($"Personnr.: {SSN}");
        return cells;
    }

    public override string ToString()
    {
        return base.ToString() + $" Personnr.: {SSN}";
    }
}
