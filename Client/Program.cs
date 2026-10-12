using Core.Models;

namespace Client;

class Program
{
    static void Main()
    {
        Console.WriteLine("Välkommen till WestCoast Education!");

        ConsoleOutputManager.WriteBreak(true);

        CourseManager.AddCourse();
        CourseManager.ListCourses();
    }
}
