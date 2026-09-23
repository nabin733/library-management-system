using (var db = new LibraryContext())
{
    db.Database.EnsureCreated();

    if (!db.Books.Any())
    {
        db.Books.Add(new Book
        {
            Title = "Nepal My Country",
            Author = "Prithivi Narayan Shah",
            ISBN = "978-0547928227",
            IsBorrowed = false
        });

        db.Books.Add(new Book
        {
            Title = "Palpa the land of hills",
            Author = "Sadhana Gnawali",
            ISBN = "978-0547928228",
            IsBorrowed = false
        });

        db.SaveChanges();
    }

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
            foreach (Book b in db.Books)
            {
                if (b.IsBorrowed)
                {
                    Console.WriteLine($"{b.Title} by {b.Author} - Borrowed by {b.BorrowedBy}");
                }
                else
                {
                    Console.WriteLine($"{b.Title} by {b.Author} - Available");
                }
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

            db.Books.Add(new Book
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                IsBorrowed = false
            });

            db.SaveChanges();

            Console.WriteLine("Book added successfully!");
        }
        else if (choice == "3")
        {
            Console.Write("Enter the title of the book to borrow: ");
            string searchTitle = Console.ReadLine();

            Console.Write("Enter your name: ");
            string borrowerName = Console.ReadLine();

            Book foundBook = db.Books.FirstOrDefault(b => b.Title == searchTitle);

            if (foundBook == null)
            {
                Console.WriteLine("Book not found.");
            }
            else if (foundBook.IsBorrowed)
            {
                Console.WriteLine($"Sorry, this book is already borrowed by {foundBook.BorrowedBy}.");
            }
            else
            {
                foundBook.IsBorrowed = true;
                foundBook.BorrowedBy = borrowerName;
                db.SaveChanges();
                Console.WriteLine($"{borrowerName} has borrowed: {foundBook.Title}");
            }
        }
        else if (choice == "4")
        {
            Console.Write("Enter the title of the book to return: ");
            string searchTitle = Console.ReadLine();

            Book foundBook = db.Books.FirstOrDefault(b => b.Title == searchTitle);

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
                Console.WriteLine($"{foundBook.BorrowedBy} has returned: {foundBook.Title}");
                foundBook.IsBorrowed = false;
                foundBook.BorrowedBy = null;
                db.SaveChanges();
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
}