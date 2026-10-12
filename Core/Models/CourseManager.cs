using Core.Enums;
using Core.Models;

namespace Core.Models;

public static class CourseManager
{
    private static string _path = Path.Combine(Environment.CurrentDirectory, "Data", "courses.json");
    private static List<Course> _allCourses = Storage<Course>.Read(_path);

    public static void AddCourse()
    {
        var course = new Course();

        course.CourseNumber = ConsoleInputManager.GetStringFromConsole("Skriv kursnummer");
        course.Title = ConsoleInputManager.GetStringFromConsole("Skriv kurstitel");
        course.CourseType = ConsoleInputManager.GetEnumFromConsole<CourseType>("Välj kurstyp");
        course.Days = ConsoleInputManager.GetIntFromConsole("Skriv antal dagar i kursen");
        course.StartDate = ConsoleInputManager.GetDateFromConsole("Skriv startdatum");
        course.EndDate = ConsoleInputManager.GetDateFromConsole("Skriv slutdatum");

        _allCourses.Add(course);
        Storage<Course>.Write(_path, _allCourses);
    }

    public static void ListCourses()
    {
        if (_allCourses.Count == 0)
        {
            Console.WriteLine("No courses found.");
        }
        else
        {
            ConsoleOutputManager.WriteList("Kurser", _allCourses.Select(o => o.ToString()).ToList()!);
        }
    }
}
