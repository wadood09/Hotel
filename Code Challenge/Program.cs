// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");


Console.WriteLine(Question2("abcdef"));
static int Question1(int num)
{
    if (num.GetLength() == 1)
    {
        return num;
    }
    else
    {
        int result = 0;
        while (num.GetLength() != 1)
        {
            while (num != 0)
            {
                result += num % 10;
                num /= 10;
            }
            num = result;
            result = 0;
        }
        return num;
    }
}

static string Question2(string s)
{
    Random random = new();
    string t = "";
    char[] alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    if (string.IsNullOrEmpty(s))
    {
        t += alpha[random.Next(0, alpha.Length)];
        return t;
    }
    else
    {
        HashSet<int> values = new();
        foreach (char item in s)
        {
            int pos = random.Next(0, s.Length);
            values.Add(pos);
        }
        foreach (int posi in values)
        {
            t += s[posi];
        }
        foreach (char item in s)
        {
            if(!t.Contains(item))
            {
                t += item;
            }
        }
        t += alpha[random.Next(0, alpha.Length)];
        return t;
    }
}

