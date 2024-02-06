using LibraryConsole;
using System.Collections.Generic;

interface IBookManager
{
    void AddBook(string title, string author, string description, decimal amount);
    void RemoveBook(string title);
    void DisplayAvailableBooks();
    List<Book> GetAllBooks();
    void BorrowBook(string title, User user);
    void ReturnBook(string title, User user);
    void BuyBook(string title, User user);
}