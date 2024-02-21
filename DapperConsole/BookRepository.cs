using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperConsole
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;
        public BookRepository(string connectionString) 
        { 
            _connectionString = connectionString;
        }


        public void EnsureBookTableExists()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Books')
                  CREATE TABLE Books (
                      Id INT IDENTITY(1,1) PRIMARY KEY,
                      Name NVARCHAR(15) NOT NULL,
                      Description NVARCHAR(100)
                  )";
                dbConnection.Execute(query);
            }
        }

        public void AddBook(Book book)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Insert into Books (Name, Description) Values (@Name, @Description)";

               // string query2 = $"Insert into Books (Name, Description) Values ({book.Name}, {book.Description})";
                dbConnection.Execute(query, book);
                //dbConnection.Execute(query2);
            }
        }

        public void DeleteBook(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Delete from Books where Id = @Id";
                //string query2 = $"Delete from Books where Id = {id}";
                dbConnection.Execute(query, new {Id = id});
                //dbConnection.Execute(query2);
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "select * from Books";
               
                return dbConnection.Query<Book>(query);
            }
        }

        public Book? GetBook(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "select * from Books where Id = @Id";

                return dbConnection.QueryFirstOrDefault<Book>(query, new {Id = id});
            }
        }

        public Book? GetBook(string name)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "select * from Books where Name = @Name";

                return dbConnection.QueryFirstOrDefault<Book>(query, new { Name = name });
            }
        }

        public void UpdateBook(Book book)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                string query = "Update Books SET Name = @Name, Description = @Description where Id = @Id";
                dbConnection.Execute(query, book);
            }
        }
    }
}
