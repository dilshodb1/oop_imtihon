using Imtihon22.Model;
using Imtihon22.Service;


namespace Imtihon22
{
    internal class Program
    {

        static void Main(string[] args)
        {
            JsonOperations.LoadData();

            while (true)
            {
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        UserService.SignUp();
                        break;
                    case "2":
                        UserService.Login();
                        break;
                    case "3":
                        JsonOperations.SaveData();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.Clear();
                        break;
                }
            }

        }


    }
}
