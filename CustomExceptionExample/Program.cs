// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int Number1, Number2, Result;
            try
            {
                Console.WriteLine("Enter First Number:");
                Number1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Second Number:");
                Number2 = int.Parse(Console.ReadLine());

                if (Number2 % 2 > 0)
                {
                    OddNumberException ONE = new OddNumberException();
                    throw ONE;
                    //throw new OddNumberException();
                }
                Result = Number1 / Number2;
                Console.WriteLine(Result);
            }
            catch (OddNumberException one)
            {
                Console.WriteLine($"Message: {one.Message}");
                Console.WriteLine($"HelpLink: {one.HelpLink}");
                Console.WriteLine($"Source: {one.Source}");
                Console.WriteLine($"StackTrace: {one.StackTrace}");
            }
            Console.WriteLine("End of the Program");
            Console.ReadKey();
public class OddNumberException : Exception
    {
        //Overriding the Message property
        public override string Message
        {
            get
            {
                return "Divisor Cannot be Odd Number";
            }
        }
        //Overriding the HelpLink Property
        public override string HelpLink
        {
            get
            {
                return "Get More Information from here: https://dotnettutorials.net/lesson/create-custom-exception-csharp/";
            }
        }
    }

    //Example 2

    //Creating our own Exception Class by inheriting Exception class with the three common constructor


    // int Number1, Number2, Result;

            
    //         try
    //         {
    //             Console.WriteLine("Enter First Number:");
    //             Number1 = int.Parse(Console.ReadLine());
    //             Console.WriteLine("Enter Second Number:");
    //             Number2 = int.Parse(Console.ReadLine());
    //             if (Number2 % 2 > 0)
    //             {
    //                 // OddNumberException ONE = new OddNumberException();
    //                 // throw ONE;
    //               throw new OddNumberException("Odd Number Exception Occured Inside");
    //             }
    //             Result = Number1 / Number2;
    //             Console.WriteLine(Result);
    //         }
    //         catch (OddNumberException one)
    //         {
    //             Console.WriteLine($"Message: {one.Message}");
    //             Console.WriteLine($"HelpLink: {one.HelpLink}");
    //             Console.WriteLine($"Source: {one.Source}");
    //             Console.WriteLine($"StackTrace: {one.StackTrace}");
    //         }
    //         Console.WriteLine("End of the Program");
    //         Console.ReadKey();
        
    
    // public class OddNumberException : Exception
    // {
    //     public OddNumberException()
    //     {
    //     }
    //     public OddNumberException(string message)
    //         : base(message)
    //     {
    //     }
    //     public OddNumberException(string message, Exception inner)
    //         : base(message, inner)
    //     {
    //     }
      
    //     //Overriding the HelpLink Property
    //     public override string HelpLink
    //     {
    //         get
    //         {
    //             return "Get More Information from here: https://dotnettutorials.net/lesson/create-custom-exception-csharp/";
    //         }
    //     }
    // }



//example 3
// try
// {
//         {
//             // Get a number from the user
//             Console.Write("Enter a positive number: ");
//             int userInput = int.Parse(Console.ReadLine());

//             // Check if the number is negative
//             if (userInput < 0)
//             {
//                 // If negative, throw the custom exception
//                 throw new NegativeNumberException();
//             }

//             // If the number is non-negative, display it
//             Console.WriteLine($"You entered: {userInput}");
//         }
//         catch (NegativeNumberException ex)
//         {
//             // Catch and handle the custom exception
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//         catch (FormatException ex)
//         {
//             // Catch and handle the format exception (e.g., if user enters non-numeric input)
//             Console.WriteLine($"Error: {ex.Message}");
//         }
//         catch (Exception ex)
//         {
//             // Catch and handle other exceptions
//             Console.WriteLine($"An unexpected error occurred: {ex.Message}");
//         }
//     }

// // Custom exception class derived from Exception
// public class NegativeNumberException : Exception
// {
//     // Constructor with a custom message
//     public NegativeNumberException() : base("Negative numbers are not allowed.")
//     {
//     }
// }

// In this example:

// The NegativeNumberException is thrown when a negative number is entered by the user.
// The try-catch block catches the NegativeNumberException specifically and displays a custom error message.
// If the user enters a non-numeric value, a FormatException is caught and handled with an appropriate message.
// Other unexpected exceptions are caught by the general Exception catch block.
// This is a basic illustration of using a custom exception in a console application. Custom exceptions become especially valuable as your application grows, providing a way to handle specific error scenarios in a more meaningful manner.