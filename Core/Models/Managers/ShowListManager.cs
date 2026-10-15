using System;

namespace Core.Models.Managers;

public class ShowListManager<T>
{
    public void ShowList(DataGroup dataGroup)
    {
        Console.WriteLine();

        List<T> objs = Storage<T>.Read(dataGroup.Path);
        
        if (objs.Count == 0)
            Console.WriteLine($"Listan med {dataGroup.TitlePlural} är tom.");
        else
            ConsoleOutputHelper.WriteList(dataGroup.TitlePlural, objs);

        Console.WriteLine();
        ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
    }
}
