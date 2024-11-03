
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BookLibrary
{
    internal class Program
    {
        static readonly List<IBook> books = [];  // List to store all books

        private static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Add a new book");
                Console.WriteLine("2 - Find a book");
                Console.WriteLine("3 - Borrow a book");
                Console.WriteLine("4 - Return a book");
                Console.Write("Enter your choice: ");
                string? input = Console.ReadLine();
                
                if (input == null)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    return;
                }
                else
                {
                    option = int.Parse(input);
                }
                
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        FindBook();
                        break;
                    case 3:
                        BorrowBook();
                        break;
                    case 4:
                        ReturnBook();
                        break;
                    default:
                        Console.WriteLine("This operation is not supported, please try again.");
                        break;
                }
            } while (option != 0);
        }

        private static void AddBook()
        {
            // Prompt user for the book type
            Console.WriteLine("Enter book type (Ebook, HardCover, AudioBook): ");
            string? type = Console.ReadLine() ?? "";

            // Prompt user for the book title
            Console.WriteLine("Enter book title: ");
            string? title = Console.ReadLine() ?? "";

            // Create a new book instance based on the type entered
            IBook book = type.ToLower() switch
            {
                "ebook" => new Ebook { Title = title },
                "hardcover" => new HardCover { Title = title },
                "audiobook" => new AudioBook { Title = title },
                _ => throw new ArgumentException("Invalid book type. Please try again.")
            };

            // Check if the book type is valid and add to list if it is
            if (book != null)
            {
                book.Title = title;  // Set the title of the book

                // Set initial properties for the new book
                if (book is HardCover hardCoverBook)
                {
                    hardCoverBook.Location = "Library";
                }

                books.Add(book);  // Add the book to the list
                Console.WriteLine($"Added {type} '{title}' to the library.");
            }
            else
            {
                Console.WriteLine("Invalid book type. Please try again.");
            }
        }

        private static void FindBook()
        {
            // Prompt user to enter the book title they are looking for
            Console.WriteLine("Enter the title of the book to find: ");
            string? title = Console.ReadLine() ?? "";

            // Search the list for a book with the given title
            IBook? foundBook = books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            // Check if the book was found
            if (foundBook != null)
            {
                string status = foundBook.IsBorrowed ? "borrowed" : "available";
                Console.WriteLine($"The book '{title}' is {status}.");
            }
            else
            {
                Console.WriteLine($"The book '{title}' does not exist in the library.");
            }
        }

        private static void BorrowBook()
        {
            // Prompt user to enter the title of the book they want to borrow
            Console.WriteLine("Enter the title of the book to borrow: ");
            string? title = Console.ReadLine() ?? "";

            // Search for the book in the list
            IBook? foundBook = books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            // If the book exists and is available, mark it as borrowed
            if (foundBook != null)
            {
                if (!foundBook.IsBorrowed)
                {
                    foundBook.MarkAsBorrowed();  // Mark book as borrowed

                    // If the book is a hardcover, change its location
                    if (foundBook is HardCover hardCoverBook)
                    {
                        hardCoverBook.Location = "Client";
                    }

                    Console.WriteLine($"You have borrowed '{title}'.");
                }
                else
                {
                    Console.WriteLine($"The book '{title}' is already borrowed.");
                }
            }
            else
            {
                Console.WriteLine($"The book '{title}' does not exist in the library.");
            }
        }

        private static void ReturnBook()
        {
            // Prompt user to enter the title of the book they want to return
            Console.WriteLine("Enter the title of the book to return: ");
            string? title = Console.ReadLine() ?? "";

            // Search for the book in the list
            IBook? foundBook = books.Find(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            // If the book is found and currently borrowed, mark it as returned
            if (foundBook != null)
            {
                if (foundBook.IsBorrowed)
                {
                    foundBook.MarkAsReturned();  // Mark book as returned

                    // If the book is a hardcover, set its location back to Library
                    if (foundBook is HardCover hardCoverBook)
                    {
                        hardCoverBook.Location = "Library";
                    }

                    Console.WriteLine($"You have returned '{title}'.");
                }
                else
                {
                    Console.WriteLine($"The book '{title}' was not borrowed.");
                }
            }
            else
            {
                Console.WriteLine($"The book '{title}' does not exist in the library.");
            }
        }
    }
}



