using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BookLibrary
{
    // Represents an electronic book, which is stored online
    public class Ebook : IBook
    {
        public required string Title { get; set; }          // Title of the book
        public bool IsBorrowed { get; private set; } = false;  // Borrowed status

        public void MarkAsBorrowed() => IsBorrowed = true;

        public void MarkAsReturned() => IsBorrowed = false;

        public string GetLocation() => "Web";
    }
}
