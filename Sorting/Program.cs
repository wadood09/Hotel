static int[] GetArrayFromUser()
{
    Console.Write("Please enter amount of numbers to be inputted: ");
    int num = int.Parse(Console.ReadLine());
    int[] numbers = new int[num];
    for (int i = 0; i < num; i++)
    {
        Console.WriteLine($"Enter [{i+1}] element ");
        numbers[i] = int.Parse(Console.ReadLine());
    }
    return numbers;
}
// int[] arr = GetArrayFromUser();
//  Array.Sort(arr);
//  foreach (int item in arr)
//  {
//     Console.Write(item);
//  }



static void BubbleSort(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < arr.Length - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int store = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = store;
            }
        }
    }

}




