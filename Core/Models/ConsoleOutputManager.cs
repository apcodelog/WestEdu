using System;

namespace Core.Models;

public static class ConsoleOutputManager
{
    public static void WriteBreak(bool large)
    {
        if (large)
            Console.WriteLine();

        Console.WriteLine("----------------------------------------------");

        if (large)
            Console.WriteLine();
    }

    public static void WriteList(string listTitle, List<string> strs)
    {
        Console.WriteLine(listTitle);
        WriteBreak(false);
        foreach (var s in strs)
            Console.WriteLine(s.ToString());
    }
}
