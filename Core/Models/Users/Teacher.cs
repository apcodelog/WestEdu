using System;
using Core.Enums;

namespace Core.Models.Users;

public class Teacher : UserBase
{
    public List<KnowledgeTagEnum> KnowledgeList { get; set; } = [];
    public List<Course> Courses { get; set; } = [];

    public override void SetUserInfo()
    {
        base.SetUserInfo();
        KnowledgeList = ConsoleInputHelper.GetKnowledgeTags("Lägg till kunskapsområden");
        Courses = ConsoleInputHelper.GetCourses("Lägg till kurser");
    }

    public override string ToString()
    {
        return base.ToString() + $" Kunskapsområden: {string.Join(", ", KnowledgeList)} Kurser: {string.Join(", ", Courses)}";
    }
}
