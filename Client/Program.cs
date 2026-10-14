using System.Runtime.Serialization.Formatters;
using Core.Interfaces;
using Core.Models;
using Core.Models.Managers;
using Core.Models.Users;

namespace Client;

class Program
{
    private readonly static DataGroup _dataGroupCourses = new(
        Path.Combine(Environment.CurrentDirectory, "Data", "courses.json"),
        "Kurs",
        "Kursen",
        "Kurser"
    );

    private readonly static DataGroup _dataGroupStudents = new(
        Path.Combine(Environment.CurrentDirectory, "Data", "students.json"),
        "Student",
        "Studenten",
        "Studenter"
    );

    private readonly static DataGroup _dataGroupTeachers = new(
        Path.Combine(Environment.CurrentDirectory, "Data", "teachers.json"),
        "Lärare",
        "Läraren",
        "Lärarer"
    );

    static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Välkommen till WestCoast Education!");
        MenuLoop();
    }

    private static void MenuLoop()
    {
        List<string> menuOptions = [
            "1 Visa alla kurser",
            "2 Visa alla studenter",
            "",
            "3 Lägg till kurs",
            "4 Lägg till student",
            "5 Lägg till lärare",
            "",
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
                    new ShowListManager<Course>(_dataGroupCourses.TitlePlural , _dataGroupCourses.Path).ShowList();
                    continue;

                case '2':
                    new ShowListManager<Student>(_dataGroupStudents.TitlePlural, _dataGroupStudents.Path).ShowList();
                    continue;

                case '3':
                    new CourseManager().Add();
                    continue;

                case '4':
                    AddUser<Student>(_dataGroupStudents);
                    continue;

                case '5':
                    AddUser<Teacher>(_dataGroupTeachers);
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

    private static void AddUser<T>(DataGroup dataGroup)
    {
        try
        {
            Console.WriteLine();
            Console.WriteLine($"Lägg till ny {dataGroup.TitleIndefinite}");

            var firstName = ConsoleInputHelper.GetString("Skriv förnamn");
            var lastName = ConsoleInputHelper.GetString("Skriv efternamn");
            var phone = ConsoleInputHelper.GetString("Skriv telefonnr.");
            var email = ConsoleInputHelper.GetString("Skriv e-post");
            var address = ConsoleInputHelper.GetAddress();
            
            if (typeof(T) == typeof(Teacher))
            {
                var courses = ConsoleInputHelper.GetCourses();
                var knowledgeList = ConsoleInputHelper.GetKnowledgeTags();

                Teacher teacher = new Teacher()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    Email = email,
                    Address = address,
                    Courses = courses,
                    KnowledgeList = knowledgeList
                };

                AddUserFinal(dataGroup, teacher);
            }
            else if (typeof(T) == typeof(Student) || typeof(T) == typeof(SchoolAdmin) || typeof(T) == typeof(CourseLeader))
            {
                var ssn = ConsoleInputHelper.GetString("Skriv personnr.");
                
                if (typeof(T) == typeof(Student))
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Phone = phone,
                        Email = email,
                        SSN = ssn,
                        Address = address
                    };

                    AddUserFinal(dataGroup, student);
                }
                else
                {
                    var hiringDate = ConsoleInputHelper.GetDate("Skriv anställningsdatum");

                    if (typeof(T) == typeof(SchoolAdmin))
                    {
                        SchoolAdmin schoolAdmin = new SchoolAdmin()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Phone = phone,
                            Email = email,
                            SSN = ssn,
                            Address = address,
                            HiringDate = hiringDate
                        };

                        AddUserFinal(dataGroup, schoolAdmin);
                    }
                    else if (typeof(T) == typeof(CourseLeader))
                    {
                        var courses = ConsoleInputHelper.GetCourses();

                        CourseLeader courseLeader = new CourseLeader()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Phone = phone,
                            Email = email,
                            SSN = ssn,
                            Address = address,
                            HiringDate = hiringDate,
                            Courses = courses
                        };

                        AddUserFinal(dataGroup, courseLeader);
                    }
                }
            }
            else
            {
                Console.WriteLine($"The type {typeof(T)} was not expected.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.WriteLine();
        ConsoleInputHelper.WaitForAnyKeyToReturnToMenu();
    }

    private static void AddUserFinal<T>(DataGroup dataGroup, T createdObj)
    {
        try
        {
            var all = Storage<T>.Read(dataGroup.Path);
            all.Add(createdObj);
            Storage<T>.Write(dataGroup.Path, all);

            Console.WriteLine($"{dataGroup.TitleDefinite} har sparats");
        }
        catch (Exception ex)
        {
            throw new Exception($"{dataGroup.TitleDefinite} kunde inte sparas. Felmeddelande: " + ex.Message);
        }
    }
}
