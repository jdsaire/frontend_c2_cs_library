#:property Nullable=disable

class LibraryManager
{
    static void Main()
    {
        string[] books = new string[5];
        bool[] checkedOut = new bool[5];
        int borrowedCount = 0;

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
                            if (checkedOut[foundIndex])
                            {
                                checkedOut[foundIndex] = false;
                                borrowedCount--;
                            }
                        }
                    }
                }
            }
            else if (action == "search")
            {
                Console.WriteLine("Enter the title of the book to search for:");
                string searchTitle = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(searchTitle))
                {
                    Console.WriteLine("Book title cannot be empty.");
                }
                else if (FindBookCaseInsensitive(books, searchTitle) == -1)
                {
                    Console.WriteLine("That book is not in the collection.");
                }
                else
                {
                    Console.WriteLine("That book is available in the collection.");
                }
            }
            else if (action == "checkout")
            {
                Console.WriteLine("Enter the title of the book to check out or check in:");
                string checkoutTitle = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(checkoutTitle))
                {
                    Console.WriteLine("Book title cannot be empty.");
                }
                else
                {
                    int foundIndex = FindBookCaseInsensitive(books, checkoutTitle);
                    if (foundIndex == -1)
                    {
                        Console.WriteLine("Book not found.");
                    }
                    else if (checkedOut[foundIndex])
                    {
                        checkedOut[foundIndex] = false;
                        borrowedCount--;
                        Console.WriteLine("Book checked in.");
                    }
                    else if (borrowedCount >= 3)
                    {
                        Console.WriteLine("Borrowing limit reached. You can only have 3 books checked out at a time.");
                    }
                    else
                    {
                        checkedOut[foundIndex] = true;
                        borrowedCount++;
                        Console.WriteLine("Book checked out.");
                    }
                }
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'checkout', or 'exit'.");
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

    static int FindBookCaseInsensitive(string[] books, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (string.Equals(books[i], title, StringComparison.OrdinalIgnoreCase))
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
