using Core.Enums;
using Core.Models;

namespace Core.Models;

public static class CourseManager
{
    private static string _path = Path.Combine(Environment.CurrentDirectory, "Data", "courses.json");
    private static List<Course> _allCourses = Storage<Course>.Read(_path);

    public static void Add()
    {
        Console.WriteLine();
        Console.WriteLine("Lägg till ny kurs");

        try
        {
            var course = new Course();

            course.CourseNumber = ConsoleInputHelper.GetStringFromConsole("Skriv kursnummer");
            course.Title = ConsoleInputHelper.GetStringFromConsole("Skriv kurstitel");
            course.CourseType = ConsoleInputHelper.GetEnumFromConsole<CourseType>("Välj kurstyp");
            course.Days = ConsoleInputHelper.GetIntFromConsole("Skriv antal dagar i kursen");
            course.StartDate = ConsoleInputHelper.GetDateFromConsole("Skriv startdatum");
            course.EndDate = ConsoleInputHelper.GetDateFromConsole("Skriv slutdatum");

            _allCourses.Add(course);
            Storage<Course>.Write(_path, _allCourses);

            Console.WriteLine("Kursen har sparats");
            Console.WriteLine();
            ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Kursen kunde inte sparas. Felmeddelande: " + ex.Message);
        }

    }

    public static void List()
    {
        Console.WriteLine();

        if (_allCourses.Count == 0)
        {
            Console.WriteLine("Kurslistan är tom.");
        }
        else
        {
            ConsoleOutputHelper.WriteList("Kurser", _allCourses.Select(o => o.ToString()).ToArray());
        }

        Console.WriteLine();
        ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
    }
}
