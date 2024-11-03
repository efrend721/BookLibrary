using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BookLibrary
{
    // Represents a hardcover book, which is stored in the library
    public class HardCover : IBook
    {
        public required string Title { get; set; }          // Title of the book
        public bool IsBorrowed { get; private set; } = false; // Borrowed status
        public string Location { get; set; } = "Library";      // Location of the book

        // Marks the book as borrowed and changes location to "Client"
        public void MarkAsBorrowed()
        {
            IsBorrowed = true;
            Location = "Client";
        }

        // Marks the book as returned and changes location to "Library"
        public void MarkAsReturned()
        {
            IsBorrowed = false;
            Location = "Library";
        }

        // Returns the current location of the book
        public string GetLocation() => Location;
    }
}
