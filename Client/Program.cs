using Core.Models;
using Core.Models.Managers;
using Core.Models.Users;

namespace Client;

class Program
{
    private static readonly string _dataPathCourses = Path.Combine(Environment.CurrentDirectory, "Data", "courses.json");
    private static readonly string _dataPathStudents = Path.Combine(Environment.CurrentDirectory, "Data", "students.json");

    static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Välkommen till WestCoast Education!");
        MenuLoop();
    }

    private static void MenuLoop()
    {
        List<string> menuOptions = [
            "1 Visa alla kurser",
            "2 Lägg till kurs",
            "",
            "3 Visa alla studenter",
            "4 Lägg till student",
            "",
            "X Avsluta"
        ];

        while (true)
        {
            Console.WriteLine();
            ConsoleOutputHelper.WriteList("Menyval", menuOptions);
            ConsoleOutputHelper.WriteBreak();
            Console.WriteLine("Välj med siffertangent eller 'X' för att avsluta");

            var choosen = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choosen)
            {
                case '1':
                    new ShowListManager<Course>("Kurser", _dataPathCourses).ShowList();
                    continue;

                case '2':
                    new CourseManager().Add();
                    continue;

                case '3':
                    new ShowListManager<Student>("Studenter", _dataPathStudents).ShowList();
                    continue;

                case '4':
                    new StudentManager().Add();
                    continue;

                case 'x':
                    Console.WriteLine("Hej då!");
                    return;
                
                default:
                    Console.WriteLine($"'{choosen}' är inte ett godkänt val. Vänligen försök igen.");
                    continue;
            }
        }
    }
}
