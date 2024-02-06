using System.Globalization;

namespace Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            // do{
            //     Console.WriteLine(no)
            //     no++;
            // }while(no < 11)



            //20!

            // int num = 5;
            // int result = 1;
            // for(int i = 1; i <= num; i++)
            // {
            //     result *= i;
            // }
            // Console.WriteLine(result);


            // for(int i = 1; i <= 20; i++)
            // {
            //     for(int j = 1; j <= 20; j ++)
            //     {
            //         Console.Write(j);
            //     }
            //     Console.WriteLine();
            // }


            // Console.WriteLine("Please enter number");
            // int num = int.Parse(Console.ReadLine());
            // for (int i = 1; i <= num;i++)
            // {
            //     if(i % 7 != 0 && i % 3 != 0)
            //     {
            //         Console.WriteLine(i);
            //     }
                
            // }

            //112358,13;



            // Console.WriteLine("Please enter the amount of numbers to be inputted");
            // int num = int.Parse(Console.ReadLine());
            // int bigno = 0;
            // long smallno = 1000000000000000000;
            // for(int i = 1;i <= num;i++)
            // {
            //     Console.WriteLine("Enter number");
            //     int number = int.Parse(Console.ReadLine());
            //     if(number > bigno)
            //     {
            //         bigno = number;
            //     }
            //     if(number < smallno)
            //     {
            //         smallno = number;
            //     }
            // }
            // Console.WriteLine($"The biggest number is {bigno} and the smallest number is {smallno}");




            // Console.WriteLine("Please enter the amount of numbers to be added");
            // int amountOfNo = int.Parse(Console.ReadLine());
            // int firstNo = 0;
            // int secondNo = 1;
            // Console.WriteLine(firstNo);
            // for(int i = 1;i <= amountOfNo;i++)
            // {
            //     int result = firstNo + secondNo;
            //     firstNo = secondNo;
            //     secondNo = result;
            //     Console.WriteLine(firstNo);
            // }



            // Console.WriteLine("Please enter 'N'");
            // int N = int.Parse(Console.ReadLine());
            // Console.WriteLine("Please enter 'K'");
            // int K = int.Parse(Console.ReadLine());
            // int result1 = 1;
            // int result2 = 1;
            // int result3 = 1;
            // for(int i = 1;i <= N;i++)
            // {
            //     result1 *= i;
            // }
            // for(int i = 1;i <= K;i++)
            // {
            //     result2 *= i;
            // }
            // for(int i = 1;i <= (N - K);i++)
            // {
            //     result3 *= i;
            // }
            // int result = result1 * result2;
            // int ans = result / result3;
            // Console.WriteLine("The answer is " + ans);




            // Console.WriteLine("Please enter number(less than 20)");
            // int N = int.Parse(Console.ReadLine());
            // for(int i = 1;i <= N;i++)
            // {
            //     for(int j = i;j <= N+i;j++)
            //     {
            //         Console.Write(j);
            //     }
            //     Console.WriteLine();
            // }




            // Console.WriteLine("Please enter catalan number to be calculated");
            // int no = int.Parse(Console.ReadLine());
            // long twoNFactorial = 1;
            // long nFactorial = 1;
            // long nPlusOneFactorial = 1;
            // for(int i = 1;i <= 2 * no;i++)
            // {
            //     twoNFactorial *= i;
            // }
            // for(int i = 1;i <= no;i++)
            // {
            //     nFactorial *= i;
            // }
            // for(int i = 1;i <= no + 1;i++)
            // {
            //     nPlusOneFactorial *= i;
            // }

            // Console.WriteLine(nFactorial);
            // Console.WriteLine(twoNFactorial);
            // Console.WriteLine(nPlusOneFactorial);
            // decimal ans = twoNFactorial / (nPlusOneFactorial * nFactorial);
            // Console.WriteLine($"The {no}th catalan number is {ans}");


            

            // Console.Write("n = ");
            // int n = int.Parse(Console.ReadLine());
            // Console.Write("x = ");
            // int x = int.Parse(Console.ReadLine());
            // double result = 1;
            // for(int i = 1;i <= n;i++)
            // {
            //     int nFactorial = 1;
            //     for(int j = 1;j <= i;j++)
            //     {
            //        nFactorial*= j;
            //     }
            //     double xPower = Math.Pow(x, i);
            //     double div = nFactorial/xPower;
            //     result += div;                          
            // }
            // Console.WriteLine(result);




            // Console.Write("Please enter N = ");
            // int n = int.Parse(Console.ReadLine());
            // long nFactorial = 1;
            // for(int i = 1;i <= n;i++)
            // {
            //     nFactorial *= i;
            // }
            // long result = nFactorial%10;
            // int count = 0;
            // while(result == 0)
            // {
            //     count++;
            //     nFactorial /= 10;
            //     result = nFactorial%10;
            // }

            // System.Console.WriteLine(count);




            // Console.Write("Enter decimal number = ");
            // int num = Convert.ToInt32(Console.ReadLine());
            // Console.Write($"The binary number of {num} is ");
            // string response = "";
            // int count = 0;
            // while(num>0)
            // {
            //     int mod = num%2;
            //     response += mod;
            //     num /= 2;
            //     count++;
            // }
            // string respond = "";
            // int response2 = int.Parse(response);
            // for(int i = 1;i <= count;i++)
            // {
            //     int result1 = response2 % 10;  
            //     respond += result1;                   
            //     response2 /= 10; 
            // }
            // Console.WriteLine($"{respond}");



            Console.Write("Enter binary number = ");
            int num = int.Parse(Console.ReadLine());
            Console.Write($"The decimal number of {num} is ");
            int pow = 0;
            double result = 0;
            while (num > 0)
            {
                int mod = num%10;
                num /= 10;
                double ans = mod * Math.Pow(2, pow);
                result += ans;
                pow++;
            }
            Console.WriteLine(result);

            

        }
    }
}

