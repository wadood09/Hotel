// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

static List<int> GetInputFromUser()
{
    Console.WriteLine("Enter numbers: ");
    List<int> arr = new();
    string input;
    while ((input = Console.ReadLine()) != "")
    {
        if (int.TryParse(input, out int num))
        {
            // Do something with num
            arr.Add(num);
        }
    }
    return arr;
}



static (int, int) SwapValues(int a, int b)
{
    (b, a) = (a, b);
    return (a, b);
}



static void Number1()
{
    Console.Write("Enter first number: ");
    int first = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int second = int.Parse(Console.ReadLine());
    Console.WriteLine($"The numbers inputted with swapped values are {SwapValues(first, second).Item1} and {SwapValues(first, second).Item2}");
}



static (int, int) GetLargestAndSmallestNumber(List<int> arr)
{
    for (int i = 0; i < arr.Count; i++)
    {
        for (int j = 0; j < arr.Count; j++)
        {
            if (arr[i] > arr[j] && j > i)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
    }
    int smallest = arr[0];
    int largest = arr[arr.Count - 1];
    return (smallest, largest);
}



static void Number2()
{
    List<int> list = GetInputFromUser();
    Console.WriteLine($"The smallest number in the range of inputted numbers is {GetLargestAndSmallestNumber(list).Item1} and the largest is {GetLargestAndSmallestNumber(list).Item2}");
}



static (int, int) NumberOfVowelAndConsonants(string str)
{
    string lowerStr = str.ToLower();
    int vowelCount = 0;
    int consonantCount = 0;
    for (int i = 0; i < str.Length; i++)
    {
        char vowel = lowerStr[i];
        if (vowel == 'a' || vowel == 'e' || vowel == 'i' || vowel == 'o' || vowel == 'u')
        {
            vowelCount++;
        }
        else
        {
            consonantCount++;
        }
    }
    return (vowelCount, consonantCount);
}



static void Number3()
{
    Console.Write("Enter word: ");
    string word = Console.ReadLine();
    Console.WriteLine($"The vowel count is {NumberOfVowelAndConsonants(word).Item1} and consonant count is {NumberOfVowelAndConsonants(word).Item2}");
}



static double AreaOfCircle(int r)
{
    double area = Math.PI * (r * r);
    return area;
}



static void Number4()
{
    Console.Write("Enter radius of circle: ");
    int radius = int.Parse(Console.ReadLine());
    Console.WriteLine($"The area of the circle is {AreaOfCircle(radius)}");
}



static bool IsPalindrome(string str)
{
    string reverse = "";
    for (int i = str.Length - 1; i >= 0; i--)
    {
        reverse += str[i];
    }
    if (str == reverse)
    {
        return true;
    }
    else
    {
        return false;
    }
}



static void Number5()
{
    Console.Write("Enter word: ");
    string word = Console.ReadLine();
    Console.WriteLine($"Is {word} a palindrome? {IsPalindrome(word)}");
}



static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
{
    int rows = (matrix1.GetLength(0) > matrix2.GetLength(0)) ? matrix1.GetLength(0) : matrix2.GetLength(0);
    int cols = (matrix1.GetLength(1) > matrix2.GetLength(1)) ? matrix1.GetLength(1) : matrix2.GetLength(1);
    int[,] matrixSum = new int[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            matrixSum[row, col] = matrix1[row, col] + matrix2[row, col];
        }
    }
    return matrixSum;
}



static int[,] GetMatrixFromUser()
{
    Console.Write("Enter the number of the rows: ");
    int rows = int.Parse(Console.ReadLine());
    Console.Write("Enter the number of the columns: ");
    int cols = int.Parse(Console.ReadLine());
    int[,] matrix = new int[rows, cols];
    Console.WriteLine("Enter the cells of the matrix:");
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write("matrix[{0},{1}] = ", row, col);
            matrix[row, col] = int.Parse(Console.ReadLine());
        }
    }
    return matrix;
}




static void Number6()
{
    Console.WriteLine("Entering first matrix: ");
    int[,] firstMatrix = GetMatrixFromUser();
    Console.WriteLine("Entering second matrix: ");
    int[,] secondMatrix = GetMatrixFromUser();
    Console.WriteLine("The sum of inputted matrices is ");
    int[,] sumMatrix = MatrixAddition(firstMatrix, secondMatrix);
    for (int row = 0; row < sumMatrix.GetLength(0); row++)
    {
        for (int col = 0; col < sumMatrix.GetLength(1); col++)
        {
            Console.Write(" " + sumMatrix[row, col]);
        }
        Console.WriteLine();
    }
}



static bool IsLeapYear(int year)
{
    if (year % 4 == 0 || year % 100 != 0 || year % 400 == 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}



static void Number7()
{
    Console.Write("Enter year to be checked: ");
    int year = int.Parse(Console.ReadLine());
    Console.WriteLine($"Is {year} a leap year? {IsLeapYear(year)}");
}



static bool IsPerfectSquare(int num)
{
    bool result = false;
    for (int i = 0; i <= num / 2; i++)
    {
        if ((i * i) == num)
        {
            return true;
        }
        else
        {
            result = false;
        }
    }
    return result;
}



static void Number9()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine($"Is {num} a perfect square? {IsPerfectSquare(num)}");
}



static string ReverseWord(string str)
{
    string reverse = "";
    for (int i = str.Length - 1; i >= 0; i--)
    {
        reverse += str[i];
    }
    return reverse;
}



static void Number10()
{
    Console.Write("Enter word: ");
    string word = Console.ReadLine();
    Console.WriteLine($"The word in reverse order is {ReverseWord(word)}");
}



static int Multiplication(int a, int b)
{
    int result = 0;
    for (int i = 1; i <= b; i++)
    {
        result += a;
    }
    return result;
}



static void Number11()
{
    Console.Write("Enter first number: ");
    int firstNum = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int secondNum = int.Parse(Console.ReadLine());
    Console.WriteLine($"{firstNum} x {secondNum} = {Multiplication(firstNum, secondNum)}");
}



static long ConvertDecimalToBinarySystem(int num)
{
    Stack<long> binary = new();
    while (num > 0)
    {
        binary.Push(num % 2);
        num /= 2;
    }
    long binarySys = 0;
    foreach (var item in binary)
    {
        binarySys += item;
    }
    return binarySys;
}



static void Number12()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine($"The binary representation of {num} is {ConvertDecimalToBinarySystem(num)}");
}



static string Concat(string a, string b)
{
    string concat = string.Concat(a, b);
    return concat;
}



static void Number13()
{
    Console.Write("Enter first word: ");
    string firstWord = Console.ReadLine();
    Console.Write("Enter second word: ");
    string secondWord = Console.ReadLine();
    Console.WriteLine($"The concatenation of {firstWord} and {secondWord} is {Concat(firstWord, secondWord)}");
}



// static bool IsNumeric(string str)
// {
//     for(int i = 0;i < str.Length;i++)
//     {

//     }
// }



static long Factorial(int num)
{
    long factorial = 1;
    for (int i = 1; i <= num; i++)
    {
        factorial *= i;
    }
    return factorial;
}



static void Number17()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine($"{num}! = {Factorial(num)}");
}



static int GetFibonacciNumber(int n, int firstNum = 0, int secondNum = 1)
{
    if (n == 0) return firstNum + secondNum;
    int result = firstNum + secondNum;
    firstNum = secondNum;
    secondNum = result;
    GetFibonacciNumber(--n, firstNum, secondNum);
    return firstNum;
}


static void Number19()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine($"Fibonacci number {num} = {GetFibonacciNumber(num)}");
}



static long GetPower(int n, int p)
{
    if (p != 0)
    {
        return n * GetPower(n, p - 1);
    }
    return 1;
}



static void Number20()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    Console.Write("Enter power: ");
    int pow = int.Parse(Console.ReadLine());
    long result = GetPower(num, pow);
    Console.WriteLine($"{num}^{pow} = {result}");
}



static double Arithmetics(int a, double b)
{
    Console.WriteLine("Press 1 for addition");
    Console.WriteLine("Press 2 for subtraction");
    Console.WriteLine("Press 3 for multiplication");
    Console.WriteLine("Press 4 for division");
    int choice = int.Parse(Console.ReadLine());
    double result = 0;
    if (choice == 1)
    { result = a + b; }
    else if (choice == 2)
    { result = a - b; }
    else if (choice == 3)
    { result = a * b; }
    else if (choice == 4)
    { result = a / b; }
    return result;
}



static void Number14()
{
    Console.Write("Enter first number: ");
    int firstNum = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int secondNum = int.Parse(Console.ReadLine());
    double result = Arithmetics(firstNum,secondNum);
    Console.WriteLine($"{result}");
}