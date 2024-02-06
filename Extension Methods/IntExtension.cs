using System.Collections;

public static class IntExtension
{
    public static long FromDecimalToBinarySystem(this int num)
    {
        Stack<int> values = new();
        long result = 0;
        while (num != 0)
        {
            int n = num % 2;
            values.Push(n);
            num /= 2;
        }
        foreach (var value in values)
        {
            result *= 10;
            result += value;
        }
        return result;
    }



    public static double FromBinaryToDecimalSystem(this int no)
    {
        string num = no.ToString();
        List<string> nums = new();
        double result = 0;
        foreach (var item in num)
        {
            nums.Add(item.ToString());
        }
        for (int i = 0; i < nums.Count; i++)
        {
            double power = Math.Pow(2, nums.Count - 1 - i);
            double multiplication = int.Parse(nums[i]) * power;
            result += multiplication;
        }
        return result;
    }



    public static string FromDecimalToHexadecimalSystem(this int no)
    {
        Stack values = new();
        string result = "";
        while (no > 0)
        {
            int store = no % 16;
            if (store > 9)
            {
                switch (store)
                {
                    case 10:
                        values.Push("A");
                        break;
                    case 11:
                        values.Push("B");
                        break;
                    case 12:
                        values.Push("C");
                        break;
                    case 13:
                        values.Push("D");
                        break;
                    case 14:
                        values.Push("E");
                        break;
                    case 15:
                        values.Push("F");
                        break;
                    default:
                        values.Push("");
                        break;
                }
            }
            else
            {
                values.Push(store                                   );
            }
            no /= 16;
        }
        foreach (var value in values)
        {
            result += value;
        }
        return result;
    }


    public static int GetLength(this long num)
    {
        string convert = num.ToString();
        int result = convert.Length;
        return result;
    }


    public static int GetLength(this int num)
    {
        string convert = num.ToString();
        int result = convert.Length;
        return result;
    }


    public static List<int> GetFactors(this int num)
    {
        List<int> factors = new();
        for(int i = 1;i <= num/2;i++)
        {
            if(num % i == 0)
            {
                factors.Add(i);
            }
        }
        factors.Add(num);
        return factors;
    }


    // public static 
}