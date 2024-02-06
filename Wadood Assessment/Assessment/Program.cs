// See https://aka.ms/new-console-template for more information
using System;

namespace assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wadood");
            // 1
            // Console.WriteLine("Please enter a number between 1 to 10");
            // int no = Convert.ToInt32(Console.ReadLine());
            // if(no >= 1 && no <= 10)
            // {
            //     Console.WriteLine("Valid");
            // }
            // else 
            // {
            //     Console.WriteLine("Invalid");
            // }
            
            // 2
            //  Console.WriteLine("Enter first number");
            //  double no1 = Convert.ToDouble(Console.ReadLine());
            //  Console.WriteLine("Enter second number");
            //  double no2 = Convert.ToDouble(Console.ReadLine());
            //  if(no1 > 10 && no2 > 10)
            //  {
            //     double sum = no1 + no2;
            //     Console.WriteLine("Their sum is "+ sum);
            //  }
            //  else if(no1 <=10 || no2 <= 10)
            //  {
            //     double product = no1 * no2;
            //     Console.WriteLine("Their product is "+ product);
            //  }

            //  3
            // Console.Write("To calculate simple interest,");
            // Console.WriteLine("please enter the values of:");
            // Console.WriteLine("Principal");
            // double P = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Rate");
            // double R = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Time");
            // double T = Convert.ToDouble(Console.ReadLine());
            // double SI = (P*R*T)/100;
            // Console.WriteLine("Your Simple Interst is "+ SI + " naira");

            // 4
            // Console.WriteLine("Enter first number");
            // double no1 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter second number");
            // double no2 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter third number");
            // double no3 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter fourth number");
            // double no4 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter fifth number");
            // double no5 = Convert.ToDouble(Console.ReadLine());
            // double sum = no1 + no2 + no3 + no4 + no5;
            // double average = sum/5;
            // Console.WriteLine($"The sum of the numbers is {sum} and their average is {average}");

            // 5
            // Console.WriteLine("Enter first number");
            // double no1 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter second number");
            // double no2 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter third number");
            // double no3 = Convert.ToDouble(Console.ReadLine());
            // double greatestNo = no1;
            // if(no2 >= greatestNo)
            // {
            //     greatestNo = no2;
            // }
            // if(no3 >= greatestNo)
            // {
            //     greatestNo = no3;
            // }
            // Console.WriteLine("The greatest number is " + greatestNo);

            // 6
            // Console.WriteLine("Please enter width of image");
            // double width = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Please enter height of image");
            // double height = Convert.ToDouble(Console.ReadLine());
            // if(width > height)
            // {
            //     Console.WriteLine("The picture is in landscape.");
            // }
            // else
            // {
            //     Console.WriteLine("The picture is in potrait.");
            // }

            //  7
            // Console.WriteLine("Please enter top edge ");
            // double edge1 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Please enter side edge 1");
            // double edge21 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Please enter side edge 2");
            // double edge22 = Convert.ToDouble(Console.ReadLine());
            // if(edge21+edge22 > edge1)
            // {
            //     double perimeter = edge1 + edge21 + edge22;
            //     Console.WriteLine("The perimeter of the triangle is " + perimeter);
            // }
            // else
            // {
            //     Console.WriteLine("INVALID INPUT");
            // }

            // 8
            // Console.WriteLine("Enter first number");
            // double no1 = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter second number");
            // double no2 = Convert.ToDouble(Console.ReadLine());
            // double no3 = 2;
            // bool isEven=no3 % 2 ==0;
            // if(no1 % 2 == 0 || no2 % 2 == 0)
            // {
            //     Console.WriteLine("TRUE");
            // }
            // else
            // {
            //     Console.WriteLine("FALSE");
            // }

            // 9
            // Console.WriteLine("Please enter number");
            // double no1 = Convert.ToDouble(Console.ReadLine());
            // if(no1 % 2 == 0)
            // {
            //     Console.WriteLine("Square of "+ no1 +" is " + no1*no1);
            // }
            // else if(no1 % 2 != 0)
            // {
            //     Console.WriteLine("the cube of " + no1 + " is " + no1*no1*no1);
            // }

            // 10
            // Console.WriteLine("Please enter radius of cylinder");
            // double radius = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Please enter lenght of cylinder");
            // double lenght = Convert.ToDouble(Console.ReadLine());
            // double pie = 3.14159265359;
            // double area = radius * pie;
            // double volume = area * lenght;
            // Console.WriteLine("The area of the cylinder is "+ area);
            // Console.WriteLine("The volume of the cylinder is "+ volume);
        }
    }
}