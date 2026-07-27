#:property Nullable=disable

class LibraryManager
{
    static void Main()
    {
        string[] books = new string[5];

        while (true)
        {
            Console.WriteLine("Would you like to add or remove a book? (add/remove/exit)");
            string action = Console.ReadLine().Trim().ToLower();

            if (action == "add")
            {
                int emptyIndex = FindEmptySlot(books);
                if (emptyIndex == -1)
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to add:");
                    string newBook = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(newBook))
                    {
                        Console.WriteLine("Book title cannot be empty.");
                    }
                    else
                    {
                        books[emptyIndex] = newBook;
                    }
                }
            }
            else if (action == "remove")
            {
                if (IsLibraryEmpty(books))
                {
                    Console.WriteLine("The library is empty. No books to remove.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to remove:");
                    string removeBook = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(removeBook))
                    {
                        Console.WriteLine("Book title cannot be empty.");
                    }
                    else
                    {
                        int foundIndex = FindBook(books, removeBook);
                        if (foundIndex == -1)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        else
                        {
                            books[foundIndex] = "";
                        }
                    }
                }
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', or 'exit'.");
            }

            DisplayBooks(books);
        }
    }

    static int FindEmptySlot(string[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrEmpty(books[i]))
            {
                return i;
            }
        }
        return -1;
    }

    static bool IsLibraryEmpty(string[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]))
            {
                return false;
            }
        }
        return true;
    }

    static int FindBook(string[] books, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] == title)
            {
                return i;
            }
        }
        return -1;
    }

    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("Available books:");
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]))
            {
                Console.WriteLine(books[i]);
            }
        }
    }
}
