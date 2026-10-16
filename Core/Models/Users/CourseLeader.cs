using System;
using Core.Models.ConsoleHelpers;
using Core.Models.Managers;

namespace Core.Models.Users;

public class CourseLeader : SchoolAdmin
{
    public List<Course> Courses { get; set; } = [];

    public override void SetUserInfo()
    {
        base.SetUserInfo();

        var courses = new Storage<Course>().Read(new DataObjectManager<Course>().GetDataGroup().Path);
        Courses = ConsoleInputHelper.GetMultiSelect(
            "Lägg till kurser", 
            courses,
            courses.Select(o => o.ToStringShort()).ToList()
            );
    }

    public override List<string> GetInfoCells()
    {
        var cells = base.GetInfoCells();
        cells.Add($"Kurser: {string.Join(", ", Courses)}");
        return cells;
    }

    public override string ToString()
    {
        return base.ToString() + $" Kurser: {string.Join(", ", Courses)}";
    }
}
