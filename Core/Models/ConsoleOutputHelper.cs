using System;

namespace Core.Models;

public static class ConsoleOutputHelper
{
    public static void WriteBreak()
    {
        Console.WriteLine("---------------------------------------------------------------------");
    }

    public static void WriteList<T>(string listTitle, List<T> objs)
    {
        Console.WriteLine(listTitle);
        WriteBreak();
        foreach (var o in objs)
        {
            if (o is null)
                Console.WriteLine("Objektet kunde inte läsas in.");
            else
                Console.WriteLine(o.ToString());
        }
    }
}
