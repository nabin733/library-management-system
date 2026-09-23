List<Book> books = new List<Book>();

books.Add(new Book
{
    Title = "Nepal My Country",
    Author = "Prithivi Narayan Shah",
    ISBN = "978-0547928227",
    IsBorrowed = false
});

books.Add(new Book
{
    Title = "Palpa the land of hills",
    Author = "Sadhana Gnawali",
    ISBN = "978-0547928228",
    IsBorrowed = false
});

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("--- Library Menu ---");
    Console.WriteLine("1. View all books");
    Console.WriteLine("2. Add a new book");
    Console.WriteLine("3. Borrow a book");
    Console.WriteLine("4. Return a book");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        foreach (Book b in books)
        {
            Console.WriteLine($"{b.Title} by {b.Author} - Borrowed: {b.IsBorrowed}");
        }
    }
    else if (choice == "2")
    {
        Console.Write("Enter title: ");
        string title = Console.ReadLine();

        Console.Write("Enter author: ");
        string author = Console.ReadLine();

        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();

        books.Add(new Book
        {
            Title = title,
            Author = author,
            ISBN = isbn,
            IsBorrowed = false
        });

        Console.WriteLine("Book added successfully!");
    }
    else if (choice == "3")
    {
        Console.Write("Enter the title of the book to borrow: ");
        string searchTitle = Console.ReadLine();

        Book foundBook = null;

        foreach (Book b in books)
        {
            if (b.Title == searchTitle)
            {
                foundBook = b;
            }
        }

        if (foundBook == null)
        {
            Console.WriteLine("Book not found.");
        }
        else if (foundBook.IsBorrowed)
        {
            Console.WriteLine("Sorry, this book is already borrowed.");
        }
        else
        {
            foundBook.IsBorrowed = true;
            Console.WriteLine($"You have borrowed: {foundBook.Title}");
        }
    }
    else if (choice == "4")
    {
        Console.Write("Enter the title of the book to return: ");
        string searchTitle = Console.ReadLine();

        Book foundBook = null;

        foreach (Book b in books)
        {
            if (b.Title == searchTitle)
            {
                foundBook = b;
            }
        }

        if (foundBook == null)
        {
            Console.WriteLine("Book not found.");
        }
        else if (!foundBook.IsBorrowed)
        {
            Console.WriteLine("This book wasn't borrowed.");
        }
        else
        {
            foundBook.IsBorrowed = false;
            Console.WriteLine($"You have returned: {foundBook.Title}");
        }
    }
    else if (choice == "5")
    {
        running = false;
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Invalid option, try again.");
    }
}