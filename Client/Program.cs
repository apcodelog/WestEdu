using System.Runtime.Serialization.Formatters;
using Core.Interfaces;
using Core.Models;
using Core.Models.Managers;
using Core.Models.Users;

namespace Client;

class Program
{
    private readonly static Dictionary<Type, DataGroup> _dataGroupMap = new()
    {
        {typeof(Course), new DataGroup(
            Path.Combine(Environment.CurrentDirectory, "Data", "courses.json"),
            "Kurs",
            "Kursen",
            "Kurser"
        )},
        {typeof(Student), new DataGroup(
            Path.Combine(Environment.CurrentDirectory, "Data", "students.json"),
            "Student",
            "Studenten",
            "Studenter"
        )},
        {typeof(Teacher), new DataGroup(
            Path.Combine(Environment.CurrentDirectory, "Data", "teachers.json"),
            "Lärare",
            "Läraren",
            "Lärarer"
        )}
    };

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
            "5 Lägg till lärare",
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
                    new ShowListManager<Course>(_dataGroupMap[typeof(Course)].TitlePlural , _dataGroupMap[typeof(Course)].Path).ShowList();
                    continue;

                case '2':
                    new ShowListManager<Student>(_dataGroupMap[typeof(Student)].TitlePlural, _dataGroupMap[typeof(Student)].Path).ShowList();
                    continue;

                case '3':
                    new CourseManager().Add();
                    continue;

                case '4':
                    AddUser<Student>();
                    continue;

                case '5':
                    AddUser<Teacher>();
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

    private static void AddUser<T>() where T : IUser, new()
    {
        var dataGroup = _dataGroupMap[typeof(T)];
        
        try
        {
            Console.WriteLine();
            Console.WriteLine($"Lägg till ny {dataGroup.TitleIndefinite}");

            T user = new T();
            user.SetUserInfo();

            var all = Storage<T>.Read(dataGroup.Path);
            all.Add(user);
            Storage<T>.Write(dataGroup.Path, all);

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
