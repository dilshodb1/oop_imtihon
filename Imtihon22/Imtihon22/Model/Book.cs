namespace Imtihon22.Model;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsRented { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsRented = false;
    }
}
