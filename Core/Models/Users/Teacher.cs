using System;
using Core.Enums;

namespace Core.Models.Users;

public class Teacher : UserBase
{
    public required List<KnowledgeTagEnum> KnowledgeList { get; set; }
    public required List<Course> Courses { get; set; }

    public override string ToString()
    {
        return base.ToString() + $" Kunskapsområden: {string.Join(", ", KnowledgeList)} Kurser: {string.Join(", ", Courses)}";
    }
}
