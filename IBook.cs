using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BookLibrary
{
    // Defines the methods that all book types must implement
    public interface IBook
    {
        string Title { get; set; }  // Property to store the book title
        bool IsBorrowed { get; }    // Read-only property to check if the book is borrowed
        void MarkAsBorrowed();  // Method to mark a book as borrowed
        void MarkAsReturned();  // Method to mark a book as returned
        string GetLocation();   // Method to get the book's location
    }
}
