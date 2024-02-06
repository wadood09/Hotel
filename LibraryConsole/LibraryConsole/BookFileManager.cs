using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsole
{
    internal class BookFileManager : IBookManager
    {
        public void AddBook(string title, string author, string description, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void BorrowBook(string title, User user)
        {
            throw new NotImplementedException();
        }

        public void BuyBook(string title, User user)
        {
            throw new NotImplementedException();
        }

        public void DisplayAvailableBooks()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(string title)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(string title, User user)
        {
            throw new NotImplementedException();
        }
    }
}
