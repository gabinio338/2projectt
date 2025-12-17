using System;

public class ConsoleUI
{
    private BookManager manager = new BookManager();
    private AuthManager auth = new AuthManager();

    public void Start()
    {
        if (!AuthMenu())
            return;

        while (true)
        {
            Console.WriteLine("\n1. Add book");
            Console.WriteLine("2. View books");
            Console.WriteLine("3. Search book");
            Console.WriteLine("4. Exit");
            Console.Write("Choose: ");

            switch (Console.ReadLine())
            {
                case "1": AddBookUI(); break;
                case "2": manager.ShowAllBooks(); break;
                case "3": SearchBookUI(); break;
                case "4": return;
                default: Console.WriteLine("Wrong choice"); break;
            }
        }
    }

    private bool AuthMenu()
    {
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Login");
        Console.Write("Choose: ");

        string choice = Console.ReadLine();

        Console.Write("Username: ");
        string user = Console.ReadLine();

        Console.Write("Password: ");
        string pass = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine(
                auth.Register(user, pass)
                ? "Registered successfully"
                : "User already exists"
            );
            return false;
        }

        if (choice == "2")
        {
            if (auth.Login(user, pass))
            {
                Console.WriteLine("Login successful");
                return true;
            }
            Console.WriteLine("Wrong credentials");
        }

        return false;
    }

    private void AddBookUI()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Year: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Invalid year");
            return;
        }

        manager.AddBook(new Book(title, author, year));
    }

    private void SearchBookUI()
    {
        Console.Write("Title: ");
        manager.SearchByTitle(Console.ReadLine());
    }
}

