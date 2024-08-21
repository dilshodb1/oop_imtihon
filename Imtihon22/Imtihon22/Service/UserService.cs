using Imtihon22.Model;

namespace Imtihon22.Service;

public class UserService : LibrarySectionService
{
    public static void SignUp()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();
        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        Console.WriteLine("Select role:");
        Console.WriteLine("1. Admin");
        Console.WriteLine("2. User");
        var roleChoice = Console.ReadLine();

        UserRole userRole;
        switch (roleChoice)
        {
            case "1":
                userRole = UserRole.Admin;
                break;
            case "2":
                userRole = UserRole.User;
                break;
            default:
                Console.WriteLine("Invalid role selection. Please try again.");
                Console.Clear();
                return;
        }

        JsonOperations.users.Add(new User(username, password, userRole));
        JsonOperations.SaveData();
        Console.WriteLine("User registered successfully!");
        Console.Clear();
        var user = JsonOperations.users.Find(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            Console.WriteLine($"Welcome, {user.Username}!");
            if (user.Role == UserRole.Admin)
            {
                AdminMenu();
            }
            else
            {
                UserMenu();
            }
        }
    }

    public static void Login()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();
        Console.Write("Enter password: ");
        var password = Console.ReadLine();
        Console.Clear();

        var user = JsonOperations.users.Find(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            Console.WriteLine($"Welcome, {user.Username}!");
            if (user.Role == UserRole.Admin)
            {
                AdminMenu();
            }
            else
            {
                UserMenu();
            }
        }
        else
        {
            Console.WriteLine("Invalid credentials. Please try again.");
            Console.Clear();
        }
    }

    public static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.WriteLine("5. Logout");

            var choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    UpdateBook();
                    break;
                case "3":
                    DeleteBook();
                    break;
                case "4":
                    ViewAllBooks();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("User Menu:");
            Console.WriteLine("1. Search Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Rent Book");
            Console.WriteLine("4. Logout");

            var choice = Console.ReadLine();
            Console.Clear();


            switch (choice)
            {
                case "1":
                    SearchBook();
                    break;
                case "2":
                    ViewAllBooks();
                    break;
                case "3":
                    RentBook();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
