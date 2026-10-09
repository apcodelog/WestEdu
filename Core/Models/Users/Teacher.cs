using System;
using Core.Enums;

namespace Core.Models.Users;

public class Teacher : User
{
    public List<KnowledgeTag> KnowledgeList { get; set; }
    public List<Course> Courses { get; set; }
}
