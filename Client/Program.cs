using Core.Models;
using Core.Models.Managers;
using Core.Models.Users;

namespace Client;

class Program
{
    private readonly static DataGroup _dataGroupCourses = new(
        Path.Combine(Environment.CurrentDirectory, "Data", "courses.json"),
        "Kurs",
        "Kursen",
        "Kurser"
    );

    private readonly static DataGroup _dataGroupStudents = new(
        Path.Combine(Environment.CurrentDirectory, "Data", "students.json"),
        "Student",
        "Studenten",
        "Studenter"
    );

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
            "2 Visa alla studenter",
            "",
            "3 Lägg till kurs",
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
                    new ShowListManager<Course>(_dataGroupCourses.TitlePlural , _dataGroupCourses.Path).ShowList();
                    continue;

                case '2':
                    new ShowListManager<Student>(_dataGroupStudents.TitlePlural, _dataGroupStudents.Path).ShowList();
                    continue;

                case '3':
                    new CourseManager().Add();
                    continue;

                case '4':
                    AddObject<Student>(_dataGroupStudents);
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

    private static void AddObject<T>(DataGroup dataGroup)
    {
        Console.WriteLine();
        Console.WriteLine($"Lägg till ny {dataGroup.TitleIndefinite}");

        try
        {
            var student = new Student()
            {
                FirstName = ConsoleInputHelper.GetString("Skriv förnamn"),
                LastName = ConsoleInputHelper.GetString("Skriv efternamn"),
                Phone = ConsoleInputHelper.GetString("Skriv telefonnr."),
                SSN = ConsoleInputHelper.GetString("Skriv personnr."),
                Address = ConsoleInputHelper.GetAddress()
            };  

            var all = Storage<Student>.Read(dataGroup.Path);
            all.Add(student);
            Storage<Student>.Write(dataGroup.Path, all);

            Console.WriteLine($"{dataGroup.TitleDefinite} har sparats");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{dataGroup.TitleDefinite} kunde inte sparas. Felmeddelande: " + ex.Message);
        }
        
        Console.WriteLine();
        ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
    }
}
