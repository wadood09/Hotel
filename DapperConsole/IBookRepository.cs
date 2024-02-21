using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperConsole
{
    public interface IBookRepository
    {
        //Repository is known as the data access layer
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
        public IEnumerable<Book> GetAllBooks();
        public Book? GetBook(int id);
        public Book? GetBook(string name);
        public void EnsureBookTableExists();
    }
}
