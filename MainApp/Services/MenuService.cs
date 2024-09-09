using MainApp.Models;

namespace MainApp.Services;

internal static class MenuService
{

    private static readonly UserService _userService = new UserService();


    private static void CreateUserMenu()
    {
        var user = new User();
        
        Console.Clear();
        Console.WriteLine("--- CREATE NEW USER---");

        Console.Write("Enter first name: ");
        user.FirstName = Console.ReadLine() ?? "";

        Console.Write("Enter last name: ");
        user.LastName = Console.ReadLine() ?? "";

        Console.Write("Enter e-mail: ");
        user.Email = Console.ReadLine() ?? "";

        Console.Write("Enter phone number: ");
        user.PhoneNumber = Console.ReadLine() ?? "";
        
        var response = _userService.CreateUser(user);
        Console.WriteLine(response.Message);

    }

    private static void ListAllUsersMenu()
    {
        Console.Clear();
        Console.WriteLine("---USER LIST ---");

        var users = _userService.GetAllUsers();
        if (users != null)
        {
            foreach (var user in _userService.GetAllUsers())
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} <{user.Email}>");
            }
        }
        else
        {
            Console.WriteLine("No user was found");
        }
    }

    private static void ExitApplicationMenu()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n)");
        var answer = Console.ReadLine() ?? "";
        if (answer.ToLower() == "y")
            Environment.Exit(0);    
    }

    private static bool MenuOptions(string selectedOption)
    {
        if (int.TryParse(selectedOption, out int option))
        {
            switch (option)
            {
                case 1:
                    CreateUserMenu();
                    Console.ReadKey();
                    break;

                case 2:
                    ListAllUsersMenu();
                    Console.ReadKey();
                    break;

                case 0:
                    ExitApplicationMenu();
                    break;

                default:
                    Console.WriteLine("Invalid option selected");
                    return false;
            }

            return true;
        }

        return false;
    }


    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("1. Create New User");
        Console.WriteLine("2. List All Users");
        Console.WriteLine("0. Exit");

        Console.WriteLine("Enter an option: ");
        MenuOptions(Console.ReadLine() ?? "");

        var result = MenuOptions(Console.ReadLine() ?? "");
        if (result == false)
        {
            Console.WriteLine("Invalid option selected");
        }
    }
}



/* 
 //fields
    private string? _fieldName = null!;

    //Properties
    public string? PropertyName { get; set; } = null!;

    //methods
    public static string MethodName(string inputParameter)
    {
        return inputParameter;
    }

    //constructors

    public MenuService()
    {
        
    }


    public MenuService(string fieldName, string propertyName)
    {
        _fieldName = fieldName;
        PropertyName = propertyName;    
    }
*/