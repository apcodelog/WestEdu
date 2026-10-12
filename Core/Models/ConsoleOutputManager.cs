using System;

namespace Core.Models;

public static class ConsoleOutputManager
{
    public static void WriteBreak()
    {
        Console.WriteLine("---------------------------------------------------------------------");
    }

    public static void WriteList(string listTitle, string[] strs)
    {
        Console.WriteLine(listTitle);
        WriteBreak();
        foreach (var s in strs)
            Console.WriteLine(s.ToString());
    }
}
