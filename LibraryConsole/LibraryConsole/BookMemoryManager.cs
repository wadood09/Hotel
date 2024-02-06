using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole
{
    class BookMemoryManager : IBookManager
    {
        private readonly List<Book> books = new List<Book>();

        public void AddBook(string title, string author, string description, decimal amount)
        {
            books.Add(new Book(title, author, description, amount));
            Console.WriteLine("Book added successfully!");
        }

        public void RemoveBook(string title)
        {
            var book = books.FirstOrDefault(b => b.Title == title);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book removed successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        public void DisplayAvailableBooks()
        {
            Console.WriteLine("Available Books:");
            foreach (var book in books)
            {
                if (book.Status == BookStatus.Available)
                    Console.WriteLine($"{book.Title} by {book.Author}: isAvailable {book.Status.ToString()}");
            }
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public void BorrowBook(string title, User user)
        {
            var book = books.FirstOrDefault(b => b.Title == title && b.Status == BookStatus.Available);
            if (book != null)
            {
                book.Status = BookStatus.Borrowed;
                Console.WriteLine($"{user.UserName} borrowed '{title}' successfully!");
            }
            else
            {
                Console.WriteLine("Book not available for borrowing!");
            }
        }

        public void ReturnBook(string title, User user)
        {
            var book = books.FirstOrDefault(b => b.Title == title && b.Status != BookStatus.Available);
            if (book != null)
            {
                book.Status = BookStatus.Available;
                Console.WriteLine($"{user.UserName} returned '{title}' successfully!");
            }
            else
            {
                Console.WriteLine("Book not borrowed by the user!");
            }
        }

        public void BuyBook(string title, User user)
        {
            var book = books.FirstOrDefault(b => b.Title == title && b.Status != BookStatus.Available);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine($"{user.UserName} bought '{title}' successfully!");
            }
            else
            {
                Console.WriteLine("Book not available for buying!");
            }
        }
    }
}
