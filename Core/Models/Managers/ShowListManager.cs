using System;

namespace Core.Models.Managers;

public class ShowListManager<T>
{
    private string _path;
    private string _listTitle;

    public ShowListManager(string listTitle, string path)
    {
        _listTitle = listTitle;
        _path = path;
    }

    public void ShowList()
    {
        Console.WriteLine();

        List<T> objs = Storage<T>.Read(_path);
        
        if (objs.Count == 0)
            Console.WriteLine("Listan är tom.");
        else
            ConsoleOutputHelper.WriteList(_listTitle, objs);

        Console.WriteLine();
        ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
    }
}
