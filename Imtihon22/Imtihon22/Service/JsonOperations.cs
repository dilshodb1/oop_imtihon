using Imtihon22.Model;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace Imtihon22.Service
{
    internal class JsonOperations
    {
        public static List<User> users = new List<User>();
        public static List<Book> books = new List<Book>();

        public static void LoadData()
        {
            try
            {
                string userFilePath = Singleton.GetUserPath();
                if (File.Exists(userFilePath))
                {
                    var userData = File.ReadAllText(userFilePath);
                    if (!string.IsNullOrWhiteSpace(userData))
                    {
                        users = JsonSerializer.Deserialize<List<User>>(userData) ?? new List<User>();
                    }
                }

                string bookFilePath = Singleton.GetBookPath();
                if (File.Exists(bookFilePath))
                {
                    var bookData = File.ReadAllText(bookFilePath);
                    if (!string.IsNullOrWhiteSpace(bookData))
                    {
                        books = JsonSerializer.Deserialize<List<Book>>(bookData) ?? new List<Book>();
                    }
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("Error reading JSON data. Starting with an empty list.");
                users = new List<User>();
                books = new List<Book>();
            }
        }

        public static void SaveData()
        {
            try
            {
                string userFilePath = Singleton.GetUserPath();
                var userData = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(userFilePath, userData);

                string bookFilePath = Singleton.GetBookPath();
                var bookData = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(bookFilePath, bookData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }
    }
}