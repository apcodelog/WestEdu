using System;

namespace Core.Models;

public static class ConsoleOutputHelper
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
