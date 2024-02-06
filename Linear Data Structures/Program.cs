using System.Collections;
using System.Data;
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello User!");
// List<int> numbers = new List<int>();
// Console.WriteLine("Enter numbers: ");
// int num;
// string input;
// while ((input = Console.ReadLine()) != "")
// {
//     if (int.TryParse(input, out num))
//     {
//         // Do something with num
//         numbers.Add(num);
//     }
// }
// Console.WriteLine($"The sum of sequence of numbers is {SumOfNumbers(numbers)}");
// Console.WriteLine($"The average of sequence of numbers is {GetAverageOfNumbers(numbers)}");



static double GetAverageOfNumbers(List<int> arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Count; i++)
    {
        sum += arr[i];
    }
    double average = sum / (double)arr.Count;
    return average;
}




static int SumOfNumbers(List<int> arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Count; i++)
    {
        sum += arr[i];
    }
    return sum;
}


// Console.WriteLine("Enter numbers: ");
// Stack<int> numbers = new Stack<int>();
// int num ;
// string input;
// while ((input = Console.ReadLine()) != "")
// {
//     if (int.TryParse(input, out num))
//     {
//         // Do something with num
//         numbers.Push(num);
//     }
// }
// foreach (int items in numbers)
// {
//     Console.Write(items + " ");
// }




// Console.WriteLine("Enter numbers: ");
// List<int> numbers = new List<int>();
// int num;
// string input;
// while ((input = Console.ReadLine()) != "")
// {
//     if (int.TryParse(input, out num))
//     {
//         // Do something with num
//         numbers.Add(num);
//     }
// }
// for(int i = 0;i < numbers.Count;i++)
// {
//     for(int j = 0;j < numbers.Count;j++)
//     {
//         if(numbers[i] > numbers[j] && j > i)
//         {
//             (numbers[i],numbers[j])=(numbers[j],numbers[i]);
//         }
//     }
// }
// foreach (int item in numbers)
// {
//     Console.Write(item + " ");
// }






// Console.WriteLine("Enter numbers: ");
// List<int> numbers = new();
// int num;
// string input;
// while ((input = Console.ReadLine()) != "")
// {
//     if (int.TryParse(input, out num))
//     {
//         // Do something with num
//         numbers.Add(num);
//     }
// }
// Console.WriteLine($"The longest subsequence of numbers inputted is {string.Join(", ", GetLongestSequenceOfEqualNumbers(numbers))}");





// Console.WriteLine("Enter numbers: ");
// List<int> numbers = new List<int>();
// int num;
// string input;
// while ((input = Console.ReadLine()) != "")
// {
//     if (int.TryParse(input, out num))
//     {
//         // Do something with num
//         numbers.Add(num);
//     }
// }
// int i = numbers.Count-1;
// while(i >= 0)
// {
//     if(numbers[i] < 0)
//     {
//         numbers.RemoveAt(i);
//     }
//     i--;
// }
// foreach (int item in numbers)
// {
//     Console.Write(item + " ");
// }








// Console.WriteLine("Enter numbers: ");
// List<int> numbers = new List<int>();
// int num;
// string input;
// while ((input = Console.ReadLine()) != "")
// {
//     if (int.TryParse(input, out num))
//     {
//         // Do something with num
//         numbers.Add(num);
//     }
// }
// List<int> oddTimes = new List<int>();
// for(int i = 0;i < numbers.Count;i++)
// {
//     int count = 0;
//     for(int j = 0;j < numbers.Count;j++)
//     {
//         if(numbers[i] == numbers[j])
//         {
//             count++;
//         }
//     }
//     if(count % 2 == 1)
//     {
//         oddTimes.Add(numbers[i]);
//     }
// }
// foreach (int item in oddTimes)
// {
//     Console.Write(item + " ");
// }




Console.WriteLine("Enter numbers: ");
List<int> numbers = new List<int>();
int num;
string input;
while ((input = Console.ReadLine()) != "")
{
    if (int.TryParse(input, out num))
    {
        // Do something with num
        numbers.Add(num);
    }
}
string response = "";
for(int i = 0;i < numbers.Count;i++)
{
    response += numbers[0];
    int count = 0;
    for(int j = 0;j < numbers.Count;j++)
    {
        if(numbers[0] == numbers[j])
        {
            count++;
        }
    }
    numbers.RemoveAll(item => item == numbers[0]);
Console.WriteLine($"Number {response[i]} occured {count} times in the array");
}


static void RemoveDuplicate()
{

    Console.WriteLine("Enter numbers: ");
    HashSet<int> arr = new();
    string input;
    while ((input = Console.ReadLine()) != "")
    {
        if (int.TryParse(input, out int num))
        {
            // Do something with num
            arr.Add(num);
        }
    }
    Console.WriteLine($"The numbers inputted without any duplicate is {string.Join(", ", arr)}");

}



static void Number2()
{
    Console.WriteLine("Enter number: ");
    Dictionary<int ,int> arr= new Dictionary<int, int>();
    string input;
    while ((input = Console.ReadLine()) != "")
    {
        if (int.TryParse(input, out int num))
        {
            if(arr.ContainsKey(num))
            {
                arr[num] += 1;
            }
            else
            {
                arr.Add(num,1); 
            }
        }
    }
    Dictionary<int,int> even = new();
    foreach (var item in arr)
    {
        if (item.Value % 2 == 0)
        {
            even.Add(item.Key,item.Value);
        }
    }
    Console.WriteLine($"The sequence without numbers that occured an odd number of times is/are {string.Join(", ",even.Keys)}");
}




static void Number3()
{
    Console.WriteLine("Enter sentence: " );
    string sentence = Console.ReadLine();
    string[] words = sentence.Split(' ',',','?','!','.','-','_',':','\\');
    Dictionary<string,int> arr = new();
    foreach (var word in words)
    {
        if(arr.ContainsKey(word))
        {
            arr[word] += 1;
        }
        else
        {
            arr.Add(word,1);
        }
    }
    var sorted = arr.OrderBy(p => p.Value);
    foreach (var item in sorted)
    {

        Console.WriteLine($"{item.Key} appears {item.Value} times");
    }
}



static void Number1()
{
    Console.WriteLine("Enter number: ");
    SortedList<int, int> arr = new();
    string input;
    while ((input = Console.ReadLine()) != "")
    {
        if (int.TryParse(input, out int num))
        {
            if (arr.ContainsKey(num))
            {
                arr[num] += 1;
            }
            else
            {
                arr.Add(num, 1);
            }
        }
    }
    foreach (KeyValuePair<int, int> item in arr)
    {
        Console.WriteLine($"{item.Key} occurs {item.Value} times in the list of numbers inputted");
    }
}
// Console.WriteLine("Enter numbers: ");
// List<int> numbers = new List<int>();
// int num;
// string input;
// while ((input = Console.ReadLine()) != "")
// {
//     if (int.TryParse(input, out num))
//     {
//         // Do something with num
//         numbers.Add(num);
//     }
// }
// List<int> majorant = new();
// for(int i = 0;i < numbers.Count;i++)
// {
//     int count = 0;
//     for(int j = 0;j < numbers.Count;j++)
//     {
//         if(numbers[i] == numbers[j])
//         {
//             count++;
//         }
//     }
//     if(count >= (numbers.Count/2)+1)
//     {
//         majorant.Add(numbers[i]);
//     }
// }
// if(majorant.Count > 0)
// {
//     Console.Write($"The majorant(s) of list of numbers inputted is: ");
//     foreach (int item in majorant)
//     {
//         Console.Write(item + " ");
//     }
// }
// else
// {
//     Console.WriteLine("The majorant does not exist");
// }




// Console.Write("Enter number: ");
// int n = int.Parse(Console.ReadLine());
// Queue<int> queue = new Queue<int>();
// for (int i = n; i <= n + 50; i++)
// {

// }

static List<int> GetLongestSequenceOfEqualNumbers(List<int> nums)
{
    int count = 1;
    int holder = 0;
    int num = 0;
    for (int i = 1; i < nums.Count; i++)
    {
        if (nums[i - 1] == nums[i])
        {
            count++;
        }
        else
        {
            if (count > holder)
            {
                holder = count;
                num = nums[i - 1];
                Console.WriteLine($"{num} enter");
            }
            count = 1;
        }
        if (i == nums.Count - 1)
        {
            if (count > holder)
            {
                holder = count;
                num = nums[i - 1];
                Console.WriteLine($"{num} enter");
            }
        }
    }
    List<int> list = new();
    for (int i = 0; i < holder; i++)
    {
        list.Add(num);
    }
    return list;
}

static void LieAttribute()
{
    Dictionary<string,string> childAttributes = new();
    Console.WriteLine("How many children are there? ");
    int num = int.Parse(Console.ReadLine());
    for(int i = 0;i < num;i++)
    {
        Console.WriteLine("Enter name of child: ");
        string child = Console.ReadLine();
        Console.WriteLine("Enter child's attributes: (Use comma to identify each attribute)");
        string attributes = Console.ReadLine();
        string[] attribute = attributes.Split(' ',',');
        childAttributes.Add(child,"");
        if(attribute.Length > 0)
        {
            for(int j = 0;j < attribute.Length;j++)
            {
                childAttributes[child] += attribute[j];
            }
        }
        Console.WriteLine();
    }
    foreach (KeyValuePair<string,string> item in childAttributes)
    {
        if(childAttributes[item.Value].Contains("lie"))
        {
            Console.WriteLine(item.Key);
        }
    }
}
LieAttribute();