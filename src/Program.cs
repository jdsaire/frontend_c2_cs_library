// Disables nullable-reference warnings from Console.ReadLine(); an SDK default, not an assignment concept
#:property Nullable=disable

class LibraryManager
{
    static void Main()
    {
        string[] books = new string[5]; // Five fixed slots; an empty slot is null or "" (both handled by IsNullOrEmpty)
        bool[] checkedOut = new bool[5]; // Parallel flag array, index-aligned with books
        int borrowedCount = 0; // Global count of currently checked-out books, capped at 3

        while (true) // Runs until the user chooses "exit"
        {
            Console.WriteLine("Would you like to add or remove a book? (add/remove/exit)");
            string action = Console.ReadLine().Trim().ToLower(); // Trim + lowercase so "Add", " ADD ", etc. all match

            if (action == "add")
            {
                int emptyIndex = FindEmptySlot(books); // -1 means every slot is taken
                if (emptyIndex == -1)
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to add:");
                    string newBook = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(newBook)) // Reject a blank title before it ever occupies a slot
                    {
                        Console.WriteLine("Book title cannot be empty.");
                    }
                    else
                    {
                        books[emptyIndex] = newBook; // Store in the first empty slot found above
                    }
                }
            }
            else if (action == "remove")
            {
                if (IsLibraryEmpty(books)) // No point prompting for a title if nothing is stored
                {
                    Console.WriteLine("The library is empty. No books to remove.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to remove:");
                    string removeBook = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(removeBook)) // Blank input would otherwise falsely "match" an already-empty slot
                    {
                        Console.WriteLine("Book title cannot be empty.");
                    }
                    else
                    {
                        int foundIndex = FindBook(books, removeBook); // Exact, case-sensitive match
                        if (foundIndex == -1)
                        {
                            Console.WriteLine("Book not found.");
                        }
                        else
                        {
                            books[foundIndex] = ""; // Free the slot
                            if (checkedOut[foundIndex]) // A removed book can't still count as borrowed
                            {
                                checkedOut[foundIndex] = false;
                                borrowedCount--;
                            }
                        }
                    }
                }
            }
            else if (action == "search") // Feature: Search (report-required)
            {
                Console.WriteLine("Enter the title of the book to search for:");
                string searchTitle = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(searchTitle))
                {
                    Console.WriteLine("Book title cannot be empty.");
                }
                else if (FindBookCaseInsensitive(books, searchTitle) == -1) // Search ignores case, unlike remove
                {
                    Console.WriteLine("That book is not in the collection.");
                }
                else
                {
                    Console.WriteLine("That book is available in the collection."); // Reports presence only, not checked-out status
                }
            }
            else if (action == "checkout") // Feature: Borrowing Limit + Check-out Flag, combined into one toggling action
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
                    else if (checkedOut[foundIndex]) // Already out -> this call checks it back in
                    {
                        checkedOut[foundIndex] = false;
                        borrowedCount--;
                        Console.WriteLine("Book checked in.");
                    }
                    else if (borrowedCount >= 3) // Only blocks new checkouts; checking a book back in is never blocked
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
                break; // Skips the display below and ends the program immediately
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'checkout', or 'exit'.");
            }

            DisplayBooks(books); // Runs after every action except exit
        }
    }

    // Returns the index of the first empty slot, or -1 if the library is full
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

    // True only when every slot is empty
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

    // Case-sensitive title lookup, used by remove; returns the matching index or -1
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

    // Case-insensitive title lookup, used by search and checkout; returns the matching index or -1
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

    // Prints every non-empty slot; empty slots are skipped, not printed as blank lines
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
