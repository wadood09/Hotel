namespace Methods
{
    class Program
    {
        public static int[] GetArrayFromUser()
        {
            Console.Write("Please enter amount of numbers to be inputted: ");
            int num = int.Parse(Console.ReadLine());
            int[] numbers = new int[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Enter index " + i);
                numbers[i] = int.Parse(Console.ReadLine());
            }
            return numbers;
        }

        static int GetMax(int num1, int num2)
        {
            return (num1 > num2) ? num1 : num2;
        }

        static string GetEnglishNameOfNumber(int number)
        {
            string englishWord = "";
            switch (number)
            {
                case 0:
                    englishWord = "Zero";
                    break;

                case 1:
                    englishWord = "One";
                    break;

                case 2:
                    englishWord = "Two";
                    break;

                case 3:
                    englishWord = "Three";
                    break;

                case 4:
                    englishWord = "Four";
                    break;

                case 5:
                    englishWord = "Five";
                    break;

                case 6:
                    englishWord = "Six";
                    break;

                case 7:
                    englishWord = "Seven";
                    break;

                case 8:
                    englishWord = "Eight";
                    break;

                case 9:
                    englishWord = "Nine";
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            return englishWord;
        }
        public static void Main(string[] args)
        {
            // Console.WriteLine("Enter first number");
            // int firstNum = int.Parse(Console.ReadLine());
            // Console.WriteLine("Enter second number");
            // int SecondNum = int.Parse(Console.ReadLine());
            // Console.WriteLine("Enter third number");
            // int thirdNum = int.Parse(Console.ReadLine());
            // int greatest = GetMax(GetMax(firstNum,SecondNum),thirdNum);
            // Console.WriteLine($"The greatest number is {greatest}");




            // Console.Write("Enter number: ");
            // int num = int.Parse(Console.ReadLine());
            // int lastDigit = num % 10;
            // Console.WriteLine($"The english name of the last digit of inputted number is {GetEnglishNameOfNumber(lastDigit)}");




            // int[] arr = GetArrayFromUser();
            // Console.WriteLine("Enter number to be found");
            // int numToBeFound = int.Parse(Console.ReadLine());
            // int count = 0;
            // for(int i = 0;i < arr.Length;i++)
            // {
            //     if(arr[i] == numToBeFound)
            //     {
            //         count++;
            //     }
            // }
            // Console.WriteLine($"{numToBeFound} can be found {GetEnglishNameOfNumber(count)} times in the array");




            // int[] arr = GetArrayFromUser();
            // Console.Write($"Enter position of array to be checked i.e between 0 and {arr.Length-1}: ");
            // int num = int.Parse(Console.ReadLine());
            // Console.WriteLine($"Is {arr[num]} greater than its neighbours? {IsNumberGreaterThanItsNeighbours(num,arr)}");




            // int[] arr = GetArrayFromUser();
            // Console.Write("Enter the element/number in the psition to be found in the array: ");
            // int num = int.Parse(Console.ReadLine());
            // Console.WriteLine($"The position of {num} in the array is {PositionOfElementInAnArray(num,arr)}");




            // Console.Write("Enter decimal number to be reversed: ");
            // int num = int.Parse(Console.ReadLine());
            // Console.WriteLine($"{num} in reverse is {ReverseNumber(num)}");





            // Console.WriteLine("Welcome");
            // Console.WriteLine("\tIf you want to print digits in reversed order;Press 1");
            // Console.WriteLine("\tIf you want to calculate the average of a given sequence of numbers;Press 2");
            // Console.WriteLine("\tIf you want to solve the linear equation a*x + b = 0;Press 3");
            // int choice = int.Parse(Console.ReadLine());
            // if(choice == 1)
            // {
            //     Console.Write("Enter number you want to reverse: ");
            //     long num = long.Parse(Console.ReadLine());
            //     if(num >= 1 && num <= 50000000)
            //     {
            //     Console.WriteLine($"The reversed order of {num} is {ReverseNumber(num)}");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid input!...ERROR!!!");
            //     }
            // }
            // else if(choice == 2)
            // {
            //     int[] arr = GetArrayFromUser();
            //     if(arr.Length >= 1)
            //     {
            //         Console.WriteLine($"The average of the sequence of numbers inputted is {GetAverageNumber(arr)}");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid input!...ERROR!!!");
            //     }
            // }
            // else if ( choice == 3)
            // {
            //     Console.WriteLine("Enter the value of a: ");
            //     int a = int.Parse(Console.ReadLine());
            //     Console.WriteLine("Enter the value of b: ");
            //     int b = int.Parse(Console.ReadLine());
            //     if(a != 0)
            //     {
            //         Console.WriteLine($"The answer to the linear equation is {SolveLinearEquation(a,b)}");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid input!...ERROR!!!");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Invalid input!...ERROR!!!");
            // }






            // int[] arr = GetArrayFromUser();
            // for(int i = 0;i < arr.Length-1;i++)
            // {
            //     for(int j = 1;j < arr.Length;j++)
            //     {
            //         if(arr[j-1] < arr[j])
            //         {
            //             int store = arr[j];
            //             arr[j] = arr[j-1];
            //             arr[j-1] = store;
            //         }

            //     }
            // }

            // foreach (int index in arr)
            // {
            //     Console.Write(index);
            // }

            



            // Console.WriteLine("Enter integer coefficients of polynomial 1 ");
            // int[] arr1 ;
            // Console.Write("Please enter amount of numbers to be inputted: ");
            // int num = int.Parse(Console.ReadLine());
            // int[] numbers = new int[num];
            // for (int i = 0; i < num; i++)
            // {
            //     Console.WriteLine("Enter index " + i);
            //     numbers[i] = int.Parse(Console.ReadLine());
            // }
            // Console.WriteLine("Enter integer coefficients of polynomial 2 ");
            // int[] arr2 ;
            // Console.Write("Please enter amount of numbers to be inputted: ");
            // int num = int.Parse(Console.ReadLine());
            // int[] numbers = new int[num];
            // for (int i = 0; i < num; i++)
            // {
            //     Console.WriteLine("Enter index " + i);
            //     numbers[i] = int.Parse(Console.ReadLine());
            // }
            // int[] answer = SolveSumOfPolynomials(arr1,arr2);
            // int length = answer.Length;
            // // Console.Write($"The sum of the polynomials is ");

            // // for(int i = 0;i < length;i++)
            // // {
            // //     Console.Write($"{answer[i]}X{length-i}");
            // // }
            // foreach (int i in answer)
            // {
            //     Console.Write(i);
            // }
                Console.WriteLine(PrintNums(10));





            // Console.WriteLine("Enter integer coefficients of polynomial 1 ");
            // int[] arr1 = GetArrayFromUser();
            // Console.WriteLine("Enter integer coefficients of polynomial 2 ");
            // int[] arr2 = GetArrayFromUser();
            // int[] answer = SolveProductOfPolynomials(arr1, arr2);
            // int length = answer.Length;
            // Console.Write($"The product of the polynomials is ");

            // for (int i = length - 1; i >= 0; i--)
            // {
            //     Console.Write($"{answer[i]}X{i}");
            // }
        }

        // static int[] SolveProductOfPolynomials(int[] firstPolynomial, int[] secondPolynomial)
        // {
            // int maxLength = (firstPolynomial.Length > secondPolynomial.Length) ? firstPolynomial.Length : secondPolynomial.Length;
            // int[] result = new int[maxLength + 1];

        // }
        // public static int PrintNums(int endDigit)
        // {
        //     if(endDigit == 1)
        //     {
        //         return endDigit;
        //     }
        //     Console.WriteLine(PrintNums(--endDigit));
        //     return endDigit;
        // }
        static int[] SolveSumOfPolynomials(int[] firstPolynomial, params int[] secondPolynomial)
        {
            int[] result = new int[(firstPolynomial.Length >= secondPolynomial.Length) ? firstPolynomial.Length : secondPolynomial.Length];
            int length2 = (firstPolynomial.Length < secondPolynomial.Length) ? firstPolynomial.Length : secondPolynomial.Length;
            for(int i = 0;i < result.Length;i++)
            {
                for(int j = 0;j < length2;j++)
                {
                    result[i] = firstPolynomial[i] + secondPolynomial[j];
                    break;
                }
            }
            Console.WriteLine(result);
            return result;
        }

        // static int ReverseArray(int[] number)
        // {
        //     string store = "";
        //     int[] reverseArray = new int[number.Length];
        //     for (int i = number.Length - 1; i >= 0; i--)
        //     {

        //     }
        //     Console.WriteLine(store);
        //     return int.Parse(store);
        // }

        static double SolveLinearEquation(int a, int b)
        {
            double x = -b / a;
            return x;
        }

        static double GetAverageNumber(int[] array)
        {
            int totalSumOfNumbers = 0;
            for (int i = 0; i < array.Length; i++)
            {
                totalSumOfNumbers += array[i];
            }
            int average = totalSumOfNumbers / array.Length;
            return average;
        }

        static int FindBiggestElementInArray(params int[] array)
        {
            double biggestElement = double.NegativeInfinity;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > biggestElement)
                {
                    biggestElement = array[i];
                }
            }
            return (int)biggestElement;
        }

        static long ReverseNumber(long number)
        {
            string response = "";
            while (number > 0)
            {
                response += number % 10;
                number /= 10;
            }
            return long.Parse(response);
        }

        static int ReverseNumber(int number)
        {
            //string response = "";
            int result = 0;
            while (number > 0)
            {
                result *= 10;
                result += number % 10;
                number /= 10;
            }
            return result;
        }

        static int PositionOfElementInAnArray(int num, int[] array)
        {
            int indexOfElement = Array.IndexOf(array, num);
            bool greater = IsNumberGreaterThanItsNeighbours(indexOfElement, array);
            if (greater == true)
            {
                return indexOfElement;
            }
            else
            {
                return -1;
            }
        }

        static bool IsNumberGreaterThanItsNeighbours(int num, params int[] array)
        {
            bool greater = false;
            if (num == 0)
            {
                if (array[num] > array[num + 1])
                {
                    return true;
                }
                return false;
            }
            if (array[num] > array[num - 1] && array[num] > array[num + 1])
            {
                greater = true;
            }
            return greater;
        }



        // static double CalculateArea(int radius)
        // {
        //     double area = Math.PI * Math.Pow(radius, 2);
        //     return area;
        // }
        // static double CalculateArea(string radius)
        // {
        //     double area = Math.PI * Math.Pow(int.Parse(radius), 2);
        //     return area;
        // }
        // static double CalculateArea(int width, int height)
        // {
        //     int area = width*height;
        //     return area;
        // }
    }
}

