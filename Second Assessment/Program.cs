// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello User!");
static void Number1()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    int result = 0;
    for (int i = 0; i <= 10; i++)
    {
        result = num * i;
        Console.WriteLine($"{num} * {i} = {result}");
    }
}



static void Number2()
{
    Console.Write("Enter a digit: ");
    int digit = int.Parse(Console.ReadLine());
    Console.Write("Enter number of rows: ");
    int row = int.Parse(Console.ReadLine());
    List<int> numbers = new();
    for (int i = 0; i < row; i++)
    {
        numbers.Add(digit);
    }
    for (int i = 1; i <= row; i++)
    {
        if (i % 2 == 1)
        {
            Console.WriteLine($"{string.Join(" ", numbers)}");
        }
        else
        {
            Console.WriteLine($"{string.Join("", numbers)}");
        }
    }
}



static void Number3()
{
    Console.Write("Enter string: ");
    string str = Console.ReadLine();
    string newString = "";
    if (str.Length >= 1)
    {
        newString = $"{str[0]}{str}{str[0]}";
    }
    else
    {
        Console.WriteLine("Invalid Input!!! String must be of length 1 or more");
    }
    Console.WriteLine($"{newString}");
}



static void Number4()
{
    List<int> sequence = new()
    {
        -10
    };
    for (int i = 0; i < 5; i++)
    {
        sequence.Add(sequence[i] + 6);
    }
    Console.WriteLine($"{string.Join(", ", sequence)}");
}



static void Number5()
{
    Console.Write("Enter range to be checked: 1...");
    int range = int.Parse(Console.ReadLine());
    Console.WriteLine($"The numbers divisible by 3 and not by 7 in the range 1...{range} are:");
    for (int i = 1; i <= range; i++)
    {
        if (i % 3 == 0 && i % 7 == 1)
        {
            Console.Write(i + " ");
        }
    }
}



static int[] GetArrayFromUser()
{
    Console.Write("Enter length of array: ");
    int num = int.Parse(Console.ReadLine());
    int[] numbers = new int[num];
    for (int i = 0; i < num; i++)
    {
        Console.WriteLine("Enter element " + (i + 1));
        numbers[i] = int.Parse(Console.ReadLine());
    }
    return numbers;
}

static void Number6()
{
    Console.WriteLine("Entering first array");
    int[] arr1 = GetArrayFromUser();
    Console.WriteLine("Entering second array");
    int[] arr2 = GetArrayFromUser();

    if (arr1.Length != arr2.Length)
    {
        Console.WriteLine("Invalid Input!!! Arrays must be of same length");
    }
    else
    {
        Console.WriteLine("The multiplication of the two arrays are:");
        for (int i = 0; i < arr1.Length; i++)
        {
            Console.Write(arr1[i] * arr2[i] + " ");
        }
    }
}



static void Number7()
{
    Console.Write("Enter score: ");
    int score = int.Parse(Console.ReadLine());
    if (score >= 1 && score <= 3)
    {
        score *= 10;
        Console.WriteLine($"New score = {score}");
    }
    else if (score >= 4 && score <= 6)
    {
        score *= 100;
        Console.WriteLine($"New score = {score}");
    }
    else if (score >= 7 && score <= 9)
    {
        score *= 1000;
        Console.WriteLine($"New score = {score}");
    }
    else
    {
        Console.WriteLine("Invalid Error!!! Score must be less than 1 and greater than 9");
    }
}



static void Number8()
{
    Console.Write("Enter number between 0 & 9");
    int number = int.Parse(Console.ReadLine());
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
    Console.WriteLine($"{number} => {englishWord}");
}



static void Number9()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    Console.WriteLine($"The first {num} natural numbers are: ");
    int sum = 0;
    for (int i = 1; i <= num; i++)
    {
        Console.Write(i + " ");
        sum += i;
    }
    Console.WriteLine($"The sum of bthe first {num} natural numbers is {sum}");
}




static void Number10()
{
    int[] arr = GetArrayFromUser();
    int[] reverse = new int[arr.Length];
    for (int i = arr.Length - 1; i >= 0; i--)
    {
        reverse[arr.Length - 1 - i] = arr[i];
    }
    Console.WriteLine($"{string.Join(" ,", reverse)}");
}



static void Number11()
{
    Console.Write("Enter amount of water in kilograms: ");
    int water = int.Parse(Console.ReadLine());
    Console.Write("Enter initial temperature of water in degree celsius: ");
    int initialTemp = int.Parse(Console.ReadLine());
    Console.Write("Enter final temperature of water in degree celsius: ");
    int finalTemp = int.Parse(Console.ReadLine());
    long energy = water * (finalTemp - initialTemp) * 4184;
    Console.WriteLine($"Energy = {water}Kg * ({finalTemp} - {initialTemp}) * 4184 = {energy}");
}



static void Number12()
{
    int[] num = GetArrayFromUser();
    int sum = 0;
    for (int i = 0; i < num.Length; i++)
    {
        sum += num[i];
    }
    Console.WriteLine($"The sum of numbers inputted is {sum}");
}



static void Number13()
{
    Console.Write("Enter minutes: ");
    long minutes = long.Parse(Console.ReadLine());
    long days = minutes / 1440;
    long year = days / 365;
    long remainingDays = days % 365;
    Console.WriteLine($"{minutes} minutes is approximately {year} year(s) and {remainingDays} day(s)");
}



static void Number14()
{
    int[] arr = GetArrayFromUser();
    HashSet<int> withoutDuplicate = new();
    for (int i = 0; i < arr.Length; i++)
    {
        withoutDuplicate.Add(arr[i]);
    }
    int duplicate = arr.Length - withoutDuplicate.Count;
    Console.WriteLine($"Total number of duplicate elements found in the array is : {duplicate}");
}



static void Number15()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    int sum = 0;
    Console.Write($"The sum of all digits in {num} = ");
    while (num > 0)
    {
        sum += num % 10;
        num /= 10;
    }
    Console.WriteLine(sum);
}



static void Number16()
{
    Console.Write("Enter subtotal: ");
    int subtotal = int.Parse(Console.ReadLine());
    Console.Write("Enter gratuity rate: ");
    double gratuityRate = int.Parse(Console.ReadLine());
    double gratuity = gratuityRate / 100 * subtotal;
    double total = gratuity + subtotal;
    Console.WriteLine($"gratuity = ${gratuity} and total = ${total}");
}



static void Number17()
{
    int[] num = GetArrayFromUser();
    Console.Write("The unique elements found in the array are : ");
    int duplicate = -1;
    for (int i = 0; i < num.Length; i++)
    {
        for (int j = 0; j < num.Length; j++)
        {
            if (num[i] == num[j])
            {
                duplicate++;
            }
        }
        if (duplicate == 0)
        {
            Console.Write(num[i] + " ");
        }
        duplicate = -1;
    }
}



static void Number18()
{
    Console.Write("Enter number: ");
    int num = int.Parse(Console.ReadLine());
    long factorial = 1;
    for (int i = 1; i <= num; i++)
    {
        factorial *= i;
    }
    Console.WriteLine($"{num}! = {factorial}");
}



static void Number19()
{
    int[] arr = GetArrayFromUser();
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[i] > arr[j] && j > i)
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
    }
    int smallest = arr[0];
    int largest = arr[arr.Length - 1];
    Console.WriteLine($"Minimum element = {smallest}");
    Console.WriteLine($"Maximum element = {largest}");
}



static void Number20()
{
    Console.Write("Enter speed limit: ");
    double speedLimit = double.Parse(Console.ReadLine());
    Console.Write("Enter current speed: ");
    double speed = double.Parse(Console.ReadLine());
    if (speed <= speedLimit)
    {
        Console.WriteLine("OK");
    }
    else
    {
        int demeritPoints = (int)(speed - speedLimit) / 5;
        Console.WriteLine($"Demerit points incurred = {demeritPoints}");
        if (demeritPoints > 12)
        {
            Console.WriteLine("License Suspended");
        }

    }
}



static void Number21()
{
    Console.Write("Enter number in pound: ");
    double pound = double.Parse(Console.ReadLine());
    double kilograms = 0.454 * pound;
    Console.WriteLine($"{pound} pounds = {kilograms} kilograms");
}



static void Number22()
{
    Console.WriteLine("Calculating average acceleration");
    Console.Write("Enter initial velocity in m/s: ");
    double initialVelocity = double.Parse(Console.ReadLine());
    Console.Write("Enter final velocity in m/s: ");
    double finalVelocity = double.Parse(Console.ReadLine());
    Console.Write("Enter time taken in s: ");
    double time = double.Parse(Console.ReadLine());
    double acceleration = (finalVelocity - initialVelocity) / time;
    Console.WriteLine($"Average acceleration = {acceleration} m/s2");
}



static void Number23()
{
    Console.Write("Enter first number: ");
    int firstNum = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int secondNum = int.Parse(Console.ReadLine());
    Console.Write("Enter third number: ");
    int thirdNum = int.Parse(Console.ReadLine());
    if (firstNum > 0 && secondNum > 0 && thirdNum > 0)
    {
        Console.WriteLine("+");
    }
    else if (firstNum > 0 && secondNum > 0 && thirdNum < 0)
    {
        Console.WriteLine("-");
    }
    else if (firstNum > 0 && secondNum < 0 && thirdNum > 0)
    {
        Console.WriteLine("-");
    }
    else if (firstNum > 0 && secondNum < 0 && thirdNum < 0)
    {
        Console.WriteLine("+");
    }
    else if (firstNum < 0 && secondNum < 0 && thirdNum < 0)
    {
        Console.WriteLine("-");
    }
    else if (firstNum < 0 && secondNum < 0 && thirdNum > 0)
    {
        Console.WriteLine("+");
    }
    else if (firstNum < 0 && secondNum > 0 && thirdNum < 0)
    {
        Console.WriteLine("+");
    }
    else if (firstNum < 0 && secondNum > 0 && thirdNum > 0)
    {
        Console.WriteLine("-");
    }
    else
    {
        Console.WriteLine("Invalid Input!!!");
    }
}



static void Number24()
{
    Console.Write("Enter number between range 0...9: ");
    int number = int.Parse(Console.ReadLine());
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
    if(number >= 0 && number <= 9)
    {
        Console.WriteLine($"{number} = {englishWord}");
    }
}



static void Number25()
{
    Console.Write("Enter four digit number e.g (2011): ");
    int num = int.Parse(Console.ReadLine());
    int d = num % 10;
    num /= 10;
    int c = num % 10;
    num /= 10;
    int b = num % 10;
    num /= 10;
    int a = num % 10;
    int sum = a+b+c+d;
    Console.WriteLine($"Sum of digits = {sum}");
    Console.WriteLine($"Number in reversed order = {d}{c}{b}{a}");
    Console.WriteLine($"Last digit in first position = {d}{a}{b}{c}");
    Console.WriteLine($"second and third digit exchanged = {a}{c}{b}{d}");
}