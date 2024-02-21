// See https://aka.ms/new-console-template for more information


//In-memory---File----Database

//Relational database
//How to connect our application to Database in C#
// 1. use of ADO.NET -- ActiveX Data object---it uses ADO.NET SqlClient to connect to the database (mysql, mssql, postgressql, sqlite)
// 2. Use of ORMs
// 1. Dapper a micro-ORM (Object Relational mapper)
// Class Book(id, name, description)--the fields are mapped as columns in the book table 
//high performance, simplicity,flexibility(more control over the sql queries), coompatibility
//practical demonstration

//Steps
//1. install Dapper
//IDbConnection
//2. Install Microsoft.Data.SqlClient

using DapperConsole;

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DapperConsole; Integrated Security=True; Connect Timeout=30;Encrypt=False;TrustServerCertificate=true;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
IBookRepository bookRepository = new BookRepository(connectionString);

// To create book Table in the DB if not exist
bookRepository.EnsureBookTableExists();

bool exit = false;
while (!exit)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Add a new Book");
    Console.WriteLine("2. Get a book by Id");
    Console.WriteLine("3. Get a book by Name");
    Console.WriteLine("4. Get all books");
    Console.WriteLine("5. Update a Book");
    Console.WriteLine("6. Delete a  Book");
    Console.WriteLine("7. Exit");

    Console.Write("Select a menu");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Enter book name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter book description");
            string description = Console.ReadLine();
            var newBook = new Book
            {
                Name = name,
                Description = description
            };
            bookRepository.AddBook(newBook);
            Console.WriteLine("Book Added succesfully");
            break;
    }
}


