public class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Year { get; private set; }

    // Constructor – creates a new book object
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    // Method for returning book information as text
    public override string ToString()
    {
        return $" Title: {Title}, Author: {Author}, Year: {Year}";
    }
}
