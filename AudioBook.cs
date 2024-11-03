using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BookLibrary
{
    // Represents an audiobook, which is stored online
    public class AudioBook : IBook
    {
        public required string Title { get; set; }          // Title of the book
        public bool IsBorrowed { get; private set; } = false;  // Borrowed status

        // Marks the book as borrowed
        public void MarkAsBorrowed() => IsBorrowed = true;

        // Marks the book as returned
        public void MarkAsReturned() => IsBorrowed = false;

        // Returns the location of the book
        public string GetLocation() => "Web";
    }
}
