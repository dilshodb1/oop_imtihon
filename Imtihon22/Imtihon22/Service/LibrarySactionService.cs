using Imtihon22.Model;

namespace Imtihon22.Service;

public class LibrarySectionService
{
    public static void AddBook()
    {
        Console.Write("Enter book title: ");
        var title = Console.ReadLine();
        Console.Write("Enter book author: ");
        var author = Console.ReadLine();
        JsonOperations.books.Add(new Book(title, author));
        JsonOperations.SaveData();
        Console.WriteLine("Book added successfully!");
        Thread.Sleep(2000);
        Console.Clear();
    }

    public static void UpdateBook()
    {
        Console.Write("Enter book title to update: ");
        var title = Console.ReadLine();
        var book = JsonOperations.books.Find(b => b.Title == title);
        if (book != null)
        {
            Console.Write("Enter new title: ");
            book.Title = Console.ReadLine();
            Console.Write("Enter new author: ");
            book.Author = Console.ReadLine();
            JsonOperations.SaveData();
            Console.WriteLine("Book updated successfully!");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Book not found.");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }

    public static void DeleteBook()
    {
        Console.Write("Enter book title to delete: ");
        var title = Console.ReadLine();
        var book = JsonOperations.books.Find(b => b.Title == title);
        if (book != null)
        {
            JsonOperations.books.Remove(book);
            JsonOperations.SaveData();
            Console.WriteLine("Book deleted successfully!");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Book not found.");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }

    public static void ViewAllBooks()
    {
        Console.WriteLine("Books in the library:");
        foreach (var book in JsonOperations.books)
        {
            Console.WriteLine($"{book.Title} by {book.Author} - {(book.IsRented ? "Rented" : "Available")}");
        }
        Console.ReadLine();
        Console.Clear();
    }

    // User methods
    public static void SearchBook()
    {
        Console.Write("Enter book title to search: ");
        var title = Console.ReadLine();
        var book = JsonOperations.books.Find(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            Console.WriteLine($"{book.Title} by {book.Author} - {(book.IsRented ? "Rented" : "Available")}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
        Thread.Sleep(2000);
        Console.Clear();
    }

    public static void RentBook()
    {
        Console.Write("Enter book title to rent: ");
        var title = Console.ReadLine();
        var book = JsonOperations.books.Find(b => b.Title == title && !b.IsRented);
        if (book != null)
        {
            book.IsRented = true;
            JsonOperations.SaveData();
            Console.WriteLine("Book rented successfully!");
        }
        else
        {
            Console.WriteLine("Book not available for rent.");
        }
        Thread.Sleep(2000);
        Console.Clear();
    }
}
