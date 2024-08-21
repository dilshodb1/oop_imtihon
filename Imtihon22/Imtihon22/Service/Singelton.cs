public class Singleton
{
    private static Singleton instance = null;
    public int Counter { get; set; }

    private Singleton()
    {
        Counter = 0;
    }

    public static Singleton Instance
    {
        get
        {
            if (instance is null)
                instance = new Singleton();
            return instance;
        }
    }

    public static string GetUserPath()
    {
        string currentPath = Directory.GetCurrentDirectory();
        currentPath = Path.Combine(currentPath, "Users.json");
        return currentPath;
    }

    public static string GetBookPath()
    {
        string currentPath = Directory.GetCurrentDirectory();
        currentPath = Path.Combine(currentPath, "Books.json");
        return currentPath;
    }
}
