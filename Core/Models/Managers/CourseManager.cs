using Core.Enums;
using Core.Interfaces;

namespace Core.Models.Managers;

public class CourseManager : IManager
{
    private readonly string _path;
    private readonly List<Course> _allCourses;

    public CourseManager()
    {
        _path = Path.Combine(Environment.CurrentDirectory, "Data", "courses.json");
        _allCourses = Storage<Course>.Read(_path);
    }

    public void Add()
    {
        Console.WriteLine();
        Console.WriteLine("Lägg till ny kurs");

        try
        {
            var course = new Course(
                ConsoleInputHelper.GetStringFromConsole("Skriv kursnummer"),
                ConsoleInputHelper.GetStringFromConsole("Skriv kurstitel"),
                ConsoleInputHelper.GetEnumFromConsole<CourseType>("Välj kurstyp"),
                ConsoleInputHelper.GetIntFromConsole("Skriv antal dagar i kursen"),
                ConsoleInputHelper.GetDateFromConsole("Skriv startdatum"),
                ConsoleInputHelper.GetDateFromConsole("Skriv slutdatum")
            );
            _allCourses.Add(course);
            Storage<Course>.Write(_path, _allCourses);

            Console.WriteLine("Kursen har sparats");
            Console.WriteLine();
            ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Kursen kunde inte sparas. Felmeddelande: " + ex.Message);
            Console.WriteLine();
            ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
        }

    }

    public void ShowList()
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
