using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole
{
    internal class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Amount { get; set; }
        public BookStatus Status { get; set; }
        public Book(string title, string description, string author, decimal amount) 
        { 
            Title = title;
            Description = description;
            Author = author;
            Status = BookStatus.Available;
        }
    }
}
