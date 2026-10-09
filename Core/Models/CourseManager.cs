using Core.Enums;
using Core.Models;

namespace Core.Models;

public static class CourseManager
{
    public static Course AddCourse()
    {
        var course = new Course();

        course.CourseNumber = ConsoleInputManager.GetStringFromConsole("Skriv kursnummer");
        course.Title = ConsoleInputManager.GetStringFromConsole("Skriv kurstitel");
        course.CourseType = ConsoleInputManager.GetEnumFromConsole<CourseType>("Välj kurstyp");
        course.Days = ConsoleInputManager.GetIntFromConsole("Skriv antal dagar i kursen");
        course.StartDate = ConsoleInputManager.GetDateFromConsole("Skriv startdatum");
        course.EndDate = ConsoleInputManager.GetDateFromConsole("Skriv slutdatum");

        return course;
    }
}
