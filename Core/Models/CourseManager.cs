using Core.Enums;
using Core.Models;

namespace Core.Models;

public static class CourseManager
{
    private static string _path = Path.Combine(Environment.CurrentDirectory, "Data", "courses.json");
    private static List<Course> _allCourses = Storage<Course>.Read(_path);

    public static void AddCourse()
    {
        Console.WriteLine();
        Console.WriteLine("Lägg till ny kurs");

        try
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

            Console.WriteLine("Kursen har sparats");
            Console.WriteLine();
            ConsoleInputManager.WaitForAnyKeyToReturnToMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Kursen kunde inte sparas. Felmeddelande: " + ex.Message);
        }

    }

    public static void ListCourses()
    {
        Console.WriteLine();

        if (_allCourses.Count == 0)
        {
            Console.WriteLine("Kurslistan är tom.");
        }
        else
        {
            ConsoleOutputManager.WriteList("Kurser", _allCourses.Select(o => o.ToString()).ToArray());
        }

        Console.WriteLine();
        ConsoleInputManager.WaitForAnyKeyToReturnToMenu();
    }
}
