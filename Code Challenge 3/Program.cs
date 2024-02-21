// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

Console.WriteLine(Question1(-132));

static string Question1(int n)
{
    n = Math.Abs(n);
    if (n == 1)
    {
        return "Richard";
    }
    int realResult = 1;
    while (n != 1)
    {
        double pow = 2;
        int count = 0;
        bool result = false;
        while (pow <= n)
        {
            count++;
            if (pow == n)
            {
                result = true;
                break;
            }
            pow = Math.Pow(pow, 2);
        }
        if (result)
        {
            n /= 2;
        }
        else
        {
            pow = 2;
            while (count != 1)
            {
                count--;
                pow *= 2;
            }
            n -= (int)pow;
        }
        realResult++;
    }
    if (realResult % 2 == 0)
        return "Louise";
    else
        return "Richard";
}


static int Question2(params int[] nums)
{
    List<int> numbers = new();
    foreach (int num in nums)
    {
        int num1 = Math.Abs(num);
        numbers.Add(num1);
        StringBuilder builder = new();
        char[] reverse = num1.ToString().Reverse().ToArray();
        foreach (char item in reverse)
        {
            builder.Append(item);
        }
        numbers.Add(int.Parse(builder.ToString()));
    }
    int result = numbers.Distinct().Count();
    return result;
}