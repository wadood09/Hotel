// public static int PrintNums(int endDigit)
// {
//     if(endDigit == 1)
//     {
//         return endDigit;
//     }
//     Console.WriteLine(PrintNums(--endDigit));
//     return endDigit;
// }



using System.Collections;

static int GetFibonacciNumber(int n, int firstNum = 0, int secondNum = 1)
{
    if (n == 0) return firstNum + secondNum;
    int result = firstNum + secondNum;
    firstNum = secondNum;
    secondNum = result;
    Console.WriteLine(firstNum);
    GetFibonacciNumber(--n, firstNum, secondNum);
    return firstNum;
}



static long SolveFactorial(int n)
{
    if (n == 0) return 1;
    long result = n * SolveFactorial(n - 1);
    return result;
}
// Console.Write("Enter number: ");
// int n = int.Parse(Console.ReadLine());
// Console.WriteLine($"{n}! = {SolveFactorial(n)}");



Console.Write("Enter first word: ");
string firstParent = Console.ReadLine();
Console.Write("Enter second word: ");
string secondParent = Console.ReadLine();
int greatestLength = (firstParent.Length > secondParent.Length) ? firstParent.Length : secondParent.Length;
string child = "";
for (int i = 0; i < firstParent.Length; i++)
{
    for (int j = 0; j < secondParent.Length; j++)
    {

        if (firstParent[i] == secondParent[j])
        {
            child += firstParent[i];
            firstParent = firstParent.Remove(i, 1);
            secondParent = secondParent.Remove(j, 1);
            i--;
            // j--;
            break;
        }
    }
}
Console.WriteLine(child);
Console.WriteLine(child.Length);

Stack st = new Stack();
Queue queue = new Queue();
