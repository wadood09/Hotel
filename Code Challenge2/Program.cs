// See https://aka.ms/new-console-template for more information

static void Question1()
{
    Console.WriteLine("Enter arriveAlice: ");
    DateOnly arriveAlice = DateOnly.Parse(Console.ReadLine());
    Console.WriteLine("Enter leaveAlice: ");
    DateOnly leaveAlice = DateOnly.Parse(Console.ReadLine());
    Console.WriteLine("Enter arriveBob: ");
    DateOnly arriveBob = DateOnly.Parse(Console.ReadLine());
    Console.WriteLine("Enter leaveBob: ");
    DateOnly leaveBob = DateOnly.Parse(Console.ReadLine());
    int alice = 0;
    while (arriveAlice < leaveAlice || arriveBob < leaveBob)
    {
        if (arriveAlice == arriveBob)
        {
            alice++;
            arriveBob = arriveBob.AddDays(1);
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
        if(appearance[i] == 1)
        {
            if(!nums.Contains(numbers[i]-1) && !nums.Contains(numbers[i] + 1))
            {
                alone.Add(nums[i]);
            }
        }
    }
    return alone;
}

string hold = Console.ReadLine();
                    while(hold == string.Empty)
                    {
                        if(hold == string.Empty)
                        {
                            Console.WriteLine("Invalid Input!!!\nTry again");
                        hold = Console.ReadLine();
                        }
                    }