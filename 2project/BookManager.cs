using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class BookManager
{
    private List<Book> books = new List<Book>();
    private string filePath = "books.json";

    public BookManager()
    {
        LoadFromFile();
    }

    private void LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(json))
                books = JsonSerializer.Deserialize<List<Book>>(json);
        }
    }

    private void SaveToFile()
    {
        File.WriteAllText(
            filePath,
            JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true })
        );
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        SaveToFile();
        Console.WriteLine("Book added!");
    }

    public void ShowAllBooks()
    {
        if (!books.Any())
        {
            Console.WriteLine("List is empty.");
            return;
        }

        books
            .OrderBy(b => b.Title)
            .ToList()
            .ForEach(b => Console.WriteLine(b));
    }

    // search ALL books with same title
    public void SearchByTitle(string title)
    {
        var foundBooks = books
            .Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (!foundBooks.Any())
        {
            Console.WriteLine("No books found.");
            return;
        }

        Console.WriteLine("Found books:");
        foundBooks.ForEach(b => Console.WriteLine(b));
    }

  