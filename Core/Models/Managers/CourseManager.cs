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
            var course = new Course()
            {
                CourseNumber = ConsoleInputHelper.GetString("Skriv kursnummer"),
                Title = ConsoleInputHelper.GetString("Skriv kurstitel"),
                CourseType = ConsoleInputHelper.GetEnum<CourseType>("Välj kurstyp"),
                Days = ConsoleInputHelper.GetInt("Skriv antal dagar i kursen"),
                StartDate = ConsoleInputHelper.GetDate("Skriv startdatum"),
                EndDate = ConsoleInputHelper.GetDate("Skriv slutdatum")
            };
                
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
}
