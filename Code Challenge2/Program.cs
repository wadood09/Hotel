// See https://aka.ms/new-console-template for more information

static void Question1()
{
    Console.WriteLine("Enter arriveAlice: ");
    DateTime arriveAlice = DateTime.Now;
    Console.WriteLine("Enter leaveAlice: ");
    DateTime leaveAlice = arriveAlice.AddDays(3);
    Console.WriteLine("Enter arriveBob: ");
    DateTime arriveBob = DateTime.Now.AddDays(2);
    Console.WriteLine("Enter leaveBob: ");
    DateTime leaveBob = arriveBob.AddDays(4);
    int alice = 0;
    while (arriveAlice < leaveAlice || arriveBob < leaveBob)
    {
        if (arriveAlice == arriveBob)
        {
           return;
        }
        arriveAlice = arriveAlice.AddMilliseconds(36000*24);
    }
    Console.WriteLine($"Total number of days alice and bob are in Rome together: {alice}");
}

static List<int> Question2(int[] nums)
{
    List<int> numbers = nums.ToList();
    List<int> appearance = new();
    for (int i = 0; i < numbers.Count; i++)
    {
        int appear = 0;
        foreach (int num in nums)
        {
            if (numbers[i] == num)
            {
                appear++;
            }
        }
        appearance.Add(appear);
    }
    List<int> alone = new();
    for (int i = 0; i < nums.Length; i++)
    {
        if (appearance[i] == 1)
        {
            if (!nums.Contains(numbers[i] - 1) && !nums.Contains(numbers[i] + 1))
            {
                alone.Add(nums[i]);
            }
        }
    }
    return alone;
}

// string hold = Console.ReadLine();
// while (hold == string.Empty)
// {
//     if (hold == string.Empty)
//     {
//         Console.WriteLine("Invalid Input!!!\nTry again");
//         hold = Console.ReadLine();
//     }
// }
Question1();