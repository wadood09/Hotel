using System;

namespace LibraryConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IUserManager userManager = new UserMemoryManager();
            IBookManager bookManager = new BookMemoryManager();
            bool isRunning = true;

            while (isRunning)
            {
                bool isLoggedIn = false;

                while (!isLoggedIn)
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter firstname: ");
                            string firstname = Console.ReadLine();
                            Console.Write("Enter lastname: ");
                            string lastmame = Console.ReadLine();
                            Console.Write("Enter username: ");
                            string regUsername = Console.ReadLine();
                            Console.Write("Enter password: ");
                            string regPassword = Console.ReadLine();
                            Console.Write("Enter email: ");
                            string email = Console.ReadLine();                            
                            userManager.RegisterUser(firstname, lastmame,regUsername, email, regPassword);
                            break;
                        case "2":
                            Console.Write("Enter username: ");
                            string loginUsername = Console.ReadLine();
                            Console.Write("Enter password: ");
                            string loginPassword = Console.ReadLine();
                            isLoggedIn = userManager.Login(loginUsername, loginPassword);
                            break;
                        case "3":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }

                // Once logged in
                while (isLoggedIn)
                {
                    Console.WriteLine("\n1. Add Book");
                    Console.WriteLine("2. Remove Book");
                    Console.WriteLine("3. Display Available Books");
                    Console.WriteLine("4. Borrow Book");
                    Console.WriteLine("5. Return Book");
                    Console.WriteLine("6. Buy Book");
                    Console.WriteLine("7. Remove User");
                    Console.WriteLine("8. Get All Users");
                    Console.WriteLine("9. Get All Books");
                    Console.WriteLine("10. Logout");
                    Console.Write("Enter your choice: ");
                    string userChoice = Console.ReadLine();
                    var currentUser = userManager.GetCurrentUser();
                    switch (userChoice)
                    {
                        case "1":
                            if (currentUser == null || !currentUser.IsAdmin)
                            {
                                Console.WriteLine("You don't have permission to add books.");
                            }
                            else
                            {
                                Console.Write("Enter title: ");
                                string title = Console.ReadLine();
                                Console.Write("Enter author: ");
                                string author = Console.ReadLine();
                                Console.Write("Enter description: ");
                                string description = Console.ReadLine();
                                Console.Write("Enter amount: ");
                                string amount = Console.ReadLine();
                                bookManager.AddBook(title, author, description, decimal.Parse(amount));
                            }
                            break;
                        case "2":
                            if (currentUser == null || !currentUser.IsAdmin)
                            {
                                Console.WriteLine("You don't have permission to add books.");
                            }
                            else
                            {
                                Console.Write("Enter title of the book to remove: ");
                                string bookToRemove = Console.ReadLine();
                                bookManager.RemoveBook(bookToRemove);
                            }

                            break;
                        case "3":
                            bookManager.DisplayAvailableBooks();
                            break;
                        case "4":
                            Console.Write("Enter title of the book to borrow: ");
                            string bookToBorrow = Console.ReadLine();
                            bookManager.BorrowBook(bookToBorrow, userManager.GetCurrentUser());
                            break;
                        case "5":
                            Console.Write("Enter title of the book to return: ");
                            string bookToReturn = Console.ReadLine();
                            bookManager.ReturnBook(bookToReturn, userManager.GetCurrentUser());
                            break;
                        case "6":
                            Console.Write("Enter title of the book to buy: ");
                            string bookToBuy = Console.ReadLine();
                            bookManager.BuyBook(bookToBuy, userManager.GetCurrentUser());
                            break;
                        case "7":

                            if (currentUser != null && currentUser.IsAdmin)
                            {
                                Console.Write("Enter username of the user to remove: ");
                                string userToRemove = Console.ReadLine();
                                userManager.RemoveUser(userToRemove);
                            }
                            else
                            {
                                Console.WriteLine("You don't have permission to remove users.");
                            }
                            break;
                        case "8":
                            var allUsers = userManager.GetUsers();
                            Console.WriteLine("All Users:");
                            foreach (var user in allUsers)
                            {
                                Console.WriteLine($"Username: {user.UserName}, Is Admin: {user.IsAdmin}");
                            }
                            break;
                        case "9":
                            var books = bookManager.GetAllBooks();
                            Console.WriteLine("All Books:");
                            foreach (var book in books)
                            {
                                Console.WriteLine($"Username: {book.Title}, Author: {book.Author}, isAvailable {book.Status.ToString()}");
                            }
                            break;
                        case "10":
                            isLoggedIn = false;
                            Console.WriteLine("Logged out successfully!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
            }
        }
    }
}
