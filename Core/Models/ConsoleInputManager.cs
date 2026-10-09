using System.Globalization;

namespace Core.Models;

public static class ConsoleInputManager
{
    public static string GetStringFromConsole(string label)
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

    public static int GetIntFromConsole(string label)
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

    public static T GetEnumFromConsole<T>(string label) where T : struct, Enum
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

    public static DateTime GetDateFromConsole(string label)
    {
        while (true)
        {
            Console.WriteLine(label + " (ÅÅÅÅ-MM-DD):");
            var str = Console.ReadLine();

            if (DateTime.TryParseExact(str, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var res))
                return res;
            
            Console.WriteLine("Vänligen försök igen");

        }
    }
}
