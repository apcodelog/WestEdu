using System;
using Core.Interfaces;
using Core.Models.Users;

namespace Core.Models.Managers;

public class StudentManager : IManager
{
    private readonly string _path;
    private readonly List<Student> _all;

    public StudentManager()
    {
        _path = Path.Combine(Environment.CurrentDirectory, "Data", "students.json");
        _all = Storage<Student>.Read(_path);
    }

    public void Add()
    {
        Console.WriteLine();
        Console.WriteLine("Lägg till ny student");

        try
        {
            var student = new Student()
            {
                FirstName = ConsoleInputHelper.GetString("Skriv förnamn"),
                LastName = ConsoleInputHelper.GetString("Skriv efternamn"),
                Phone = ConsoleInputHelper.GetString("Skriv telefonnr."),
                SSN = ConsoleInputHelper.GetString("Skriv personnr."),
                Address = ConsoleInputHelper.GetAddress()
            };  

            _all.Add(student);
            Storage<Student>.Write(_path, _all);

            Console.WriteLine("Studenten har sparats");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Kursen kunde inte sparas. Felmeddelande: " + ex.Message);
        }

        
        Console.WriteLine();
        ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
    }
}
