// See https://aka.ms/new-console-template for more information

static void Question1()
{
    Console.WriteLine("Enter arriveAlice: ");
    DateTime arriveAlice = DateTime.Parse("08:12");
    Console.WriteLine("Enter leaveAlice: ");
    DateTime leaveAlice = DateTime.Parse("08:17");
    Console.WriteLine("Enter arriveBob: ");
    DateTime arriveBob = DateTime.Parse("08:14");
    Console.WriteLine("Enter leaveBob: ");
    DateTime leaveBob = DateTime.Parse("08:20");
    int alice = 0;
    while (arriveAlice < leaveAlice || arriveBob < leaveBob)
    {
        if (arriveAlice == arriveBob)
        {
           return;
        }
        arriveAlice = arriveAlice.AddDays(1);
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