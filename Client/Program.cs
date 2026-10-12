using Core.Models;

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
        string[] menuOptions = [
            "1 Visa alla kurser",
            "2 Lägg till kurs",
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
                    CourseManager.List();
                    continue;

                case '2':
                    CourseManager.Add();
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
