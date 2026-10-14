using System;

namespace Core.Models.Users;

public class CourseLeader : SchoolAdmin
{
    public required List<Course> Courses { get; set; }

    public override string ToString()
    {
        return base.ToString() + $" Kurser: {string.Join(", ", Courses)}";
    }
}
