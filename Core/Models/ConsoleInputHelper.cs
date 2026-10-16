using System.Globalization;
using Core.Enums;

namespace Core.Models;

public static class ConsoleInputHelper
{
    public static void WaitForAnyKeyToReturnToMenu()
    {
        Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till menyn");
        Console.ReadKey(true);
    }

    public static string GetString(string label)
    {
        while (true)
        {
            Console.WriteLine(label + ':');
            var str = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(str))
                return str;
            
            Console.WriteLine("Vänligen försök igen");
        }
    }

    public static int GetInt(string label)
    {
        while (true)
        {
            Console.WriteLine(label + ':');
            var str = Console.ReadLine();

            if (int.TryParse(str, out var res))
                return res;
            
            Console.WriteLine("Vänligen försök igen");
        }
    }

    public static T GetEnum<T>(string label) where T : struct, Enum
    {
        while (true)
        {
            Console.WriteLine(label + ':');
            int i = 1;
            var options = Enum.GetValues<T>();
            foreach (T option in options)
            {
                Console.WriteLine(i + " " + option);
                i++;
            }

            var str = Console.ReadLine();

            if (int.TryParse(str, out int index))
            {
                index--; // User input starts from 1
                if (0 <= index && index < options.Length)
                    return options[index];
            }
            
            Console.WriteLine("Vänligen försök igen");
        }
    }

    public static DateOnly GetDate(string label)
    {
        while (true)
        {
            Console.WriteLine(label + " (ÅÅÅÅ-MM-DD):");
            var str = Console.ReadLine();

            if (DateOnly.TryParseExact(str, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var res))
                return res;
            
            Console.WriteLine("Vänligen försök igen");

        }
    }

    public static Address GetAddress()
    {
        return new Address()
        {
            StreetAddress = GetString("Skriv gatuadress"),
            PostalCode = GetString("Skriv postkod"),
            Town = GetString("Skriv stad"),
            Country = GetString("Skriv land")
        };
    }

    public static List<Course> GetCourses(string label)
    {
        Console.WriteLine("Not implemented.");
        return [];
    }

    public static List<KnowledgeTagEnum> GetKnowledgeTags(string label)
    {
        Console.WriteLine("Not implemented.");
        return [];
    }
}
