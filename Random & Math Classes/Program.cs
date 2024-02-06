

namespace Random_and_Math_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello User!");
            // Random rand = new();
            // int num = rand.Next(10);
            // Console.Write("Enter negative number: ");
            // double negative = double.Parse(Console.ReadLine());
            // double absolute = Math.Abs(negative);
            // Console.WriteLine($"The absolute value of {negative} is {absolute}");
            double power = Math.Floor(3.19);
            double ceiling = Math.Ceiling(3.19);
            Console.WriteLine(power + " " + ceiling);
        }
        static void Registration()
        {
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your middle name: ");
            string middleName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your batch: ");
            int batch = int.Parse(Console.ReadLine());
            string registration = GetRegistrationNumber(batch);
            Console.WriteLine($"Hello {firstName} {middleName} {lastName},you are in batch {batch} and your registration number is {registration}");
        }
        
        private static string GetRegistrationNumber(int batch)
        {
            Random rand = new();
            int num = rand.Next(1000, 10000);
            char[] alpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var pos1 = rand.Next(0, alpha.Length);
            var pos2 = rand.Next(0, alpha.Length);
            var letters = $"{alpha[pos1]}{alpha[pos2]}";
            return $"{num}{letters}";
        }

        static void Assignment()
        {
            Console.WriteLine("Hello User!");
            Console.WriteLine("Enter number between 0-50: ");
            int num = int.Parse(Console.ReadLine());
            Random rand = new();
            int random = rand.Next(50);
            int count = 1;
            while (count <= 3)
            {
                if (num == random)
                {
                    Console.WriteLine("Congratulations!!!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                    int num2 = int.Parse(Console.ReadLine());
                }
                count++;
            }
            if (count == 4)
            {
                Console.WriteLine("You have lost all chances.Try again later");
            }
 
        }
    }
}