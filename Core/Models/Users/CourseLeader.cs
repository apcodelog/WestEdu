using System;

namespace Core.Models.Users;

public class CourseLeader : SchoolAdmin
{
    public List<Course> Courses { get; set; }
}
