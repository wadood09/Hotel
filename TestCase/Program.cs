using System.Globalization;

static string timeConversion(string s)
{
    string result = "";
    string[] num = s.Split(':');
    if (num[2].Contains('A'))
    {
        if (num[0].Contains("12"))
        {
            num[0] = "00";
            string o = string.Join(":", num);
            result += o.Remove(o.Length - 2);
        }
        else
        {
            string m = string.Join(":", num);
            result += m.Remove(m.Length - 2);
        }
    }
    else
    {
        if (num[0].Contains('1') && num[0].Contains('2'))
        {
            num[0] = 12.ToString();
            string d = string.Join(":", num);
            result += d.Remove(d.Length - 2);
        }
        else
        {
            // num[0].Remove(num[0][0]);
            int n = int.Parse(num[0]);
            n += 12;
            num[0] = n.ToString();
            string f = string.Join(":", num);
            result += f.Remove(f.Length - 2);
        }
    }
    return result;
}



static void ToDecimalSystem(int no)
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
    Console.WriteLine(result);
}



// static bool DateTimeComparison()
// {
//     DateTime currentTime = DateTime.Now;
//     DateTime x1MinLater = currentTime.AddMinutes(1);

// }


// DateTime currentTime = DateTime.Now;
// int n = int.Parse(Console.ReadLine());
// DateTime test = DateTime.Now;
// Console.WriteLine(currentTime + " " + test);


static void Reverse(string str)
{
    string s = str.Reverse().ToString();
    Console.WriteLine(s);
}
// string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// var reversedIDigits = (
//     from digit in digits
//     where digit[1] == 'i'
//     select digit)
//     .Reverse();

// Console.WriteLine("A backwards list of the digits with a second character of 'i':");
// foreach (var d in reversedIDigits)
// {
//     Console.WriteLine(d);
// }

 UnauthorizedAccessException exception = new();
Console.WriteLine(exception.Message);