using System.Runtime.Serialization.Formatters;
using Core.Interfaces;
using Core.Models;
using Core.Models.ConsoleHelpers;
using Core.Models.Managers;
using Core.Models.Users;

namespace Client;

class Program
{
    static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Välkommen till WestCoast Education!");
        MenuLoop();
    }

    private static void MenuLoop()
    {
        List<string> menuLines = [
            "1 Lägg till kurs                       6 Visa alla kurser",
            "2 Lägg till student                    7 Visa alla studenter",
            "3 Lägg till lärare",
            "4 Lägg till utbildningsledare",
            "5 Lägg till administratör",
            "",
            "X Avsluta"
        ];

        while (true)
        {
            Console.WriteLine();

            Console.WriteLine("Meny");
            ConsoleOutputHelper.WriteBreak();
            foreach (var line in menuLines)
            {
                Console.WriteLine(line);
            }
            ConsoleOutputHelper.WriteBreak();
            Console.WriteLine("Välj med siffertangent eller 'X' för att avsluta");

            var choosen = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choosen)
            {
                case '1':
                    new DataObjectManager<Course>().AddObject();
                    continue;

                case '2':
                    new DataObjectManager<Student>().AddObject();
                    continue;

                case '3':
                    new DataObjectManager<Teacher>().AddObject();
                    continue;

                case '4':
                    new DataObjectManager<CourseLeader>().AddObject();
                    continue;

                case '5':
                    new DataObjectManager<SchoolAdmin>().AddObject();
                    continue;

                case '6':
                    new DataObjectManager<Course>().ShowList();
                    continue;

                case '7':
                    new DataObjectManager<Student>().ShowList();
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
