using System;

namespace Core.Models.Users;

public class CourseLeader : SchoolAdmin
{
    public List<Course> Courses { get; set; } = [];

    public override void SetUserInfo()
    {
        base.SetUserInfo();
        Courses = ConsoleInputHelper.GetCourses("Lägg till kurser");
    }

    public override string ToString()
    {
        return base.ToString() + $" Kurser: {string.Join(", ", Courses)}";
    }
}
