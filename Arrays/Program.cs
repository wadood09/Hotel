// See https://aka.ms/new-console-template for more information
//int[] arr = {1, 2, 3, 4};
int[] nums = new int[20];
for(int index = 0;index < 20;index++)
{
    nums[index] = index*5;
}
foreach (int numbers in nums)
{
    Console.WriteLine(numbers);
}

for(int i = nums.Length-1; i >= 0 ; i--)
{
    Console.WriteLine(nums[i]);
}




// Console.Write("Please enter amount of numbers to be inputted: " );
// int num = int.Parse(Console.ReadLine());
// int[] numbers= new int [num];
// for(int i = 0;i < num;i++)
// {
//     Console.WriteLine("Enter index " + i);
//     numbers[i] = int.Parse(Console.ReadLine());
// }
// foreach (int item in numbers)
// {
//     Console.Write(item + " ");
// }



// int[] symmetric = { 1, 2, 3, 3, 2, 1};
// int[,] multidimensional = new int[2, 4]{
//     {2 ,4, 5, 6},
//     {9 ,4 ,6 ,7}
// };
// for(int row = 0;row < multidimensional.GetLength(0);row++)
// {
//     for(int col = 0;col < multidimensional.GetLength(1);col++)
//     {
//         Console.Write(multidimensional[row, col]);
//     }
//     Console.WriteLine();
// }




// Console.Write("Please enter 'm' for row: ");
// int m = int.Parse(Console.ReadLine());
// Console.Write("Please enter 'n' for column: ");
// int n = int.Parse(Console.ReadLine());
// int[,] multArr = new int [m,n];
// for(int row = 0;row < multArr.GetLength(0);row++)
// {
//     for(int col = 0;col < multArr.GetLength(1);col++)
//     {
//         Console.WriteLine($"Enter arr at index {row}, {col}");
//         multArr[row, col] = int.Parse(Console.ReadLine());
//     }
//     Console.WriteLine();
// }

// int[][] arr = {new int[]{1, 2}, new int[]{2, 4}};
// for(int i = 0; i < arr.Length; i++)
// {
//     for(int j = 0; j < arr[i].Length; j ++)
//     {
//         Console.WriteLine(arr[i][j]);
//     }
// }
int[] arrayofNumbers = {4, 1, 8, 5, 3, 8, 9, 3, 4};
//{1, 3, 3, 4, 4, 5, 7, 8, 9};
for(int i = 0; i < arrayofNumbers.Length; i++)
{
    for(int j = 0; j < arrayofNumbers.Length; j++)
    {
        if(arrayofNumbers[i] > arrayofNumbers[j] && j > i)
        {
            int store = arrayofNumbers[i];
            arrayofNumbers[i] = arrayofNumbers[j];
            arrayofNumbers[j] = store;
        }        

    }
}
foreach (int numbers in arrayofNumbers)
{
    Console.Write(numbers + " ");
}




// Console.Write("Please enter amount of numbers to be inputted in the first array: " );
// int num1 = int.Parse(Console.ReadLine());
// Console.Write("Please enter amount of numbers to be inputted in the second array: " );
// int num2 = int.Parse(Console.ReadLine());
// int[] numbers1= new int [num1];
// int[] numbers2= new int [num2];
// int length1 = numbers1.Length;
// int length2 = numbers2.Length;
// for(int i = 0;i < length1;i++)
// {
//     Console.WriteLine("Enter index " + i + " of first array");
//     numbers1[i] = int.Parse(Console.ReadLine());
// }
// for(int i = 0;i < length2;i++)
// {
//     Console.WriteLine("Enter index " + i + " of second array");
//     numbers2[i] = int.Parse(Console.ReadLine());
// }
// bool equal = false;
// if(length1 == length2)
// {
//     for(int i = 0;i < length1;i++)
//     {
        
        
//             if (numbers1[i] == numbers2[i])
//             {
//                 equal = true;
//             }
//             else
//             {
//                 equal = false;
//                 break;
//             }
        
//     }
// }
// Console.WriteLine($"Are the arrays equal? {equal}");





// {r, y, i, o, p, w, c}
// {a, y, b, o, p, w, c}




// Console.Write("Please enter amount of characters to be inputted in the first array: " );
// int char1= int.Parse(Console.ReadLine());
// Console.Write("Please enter amount of numbers to be inputted in the second array: " );
// int char2 = int.Parse(Console.ReadLine());
// char[] characters1= new char [char1];
// char[] characters2= new char [char2];
// int length1 = characters1.Length;
// int length2 = characters2.Length;
// for(int i = 0;i < length1;i++)
// {
//     Console.WriteLine("Enter index " + i + " of first array");
//     characters1[i] = char.Parse(Console.ReadLine());
// }
// for(int i = 0;i < length2;i++)
// {
//     Console.WriteLine("Enter index " + i + " of second array");
//     characters2[i] = char.Parse(Console.ReadLine());
// }
// for(int i = 0;i >= 0;i++)
// {
//     if(characters1[i] > characters2[i])
//     {
//         Console.WriteLine("Array 1 is first in the lexicographical order");
//         break;
//     }
//     else
//     {
//         Console.WriteLine("Array 2 is first in the lexicographical order");
//         break;
//     }
// }





// Console.Write("Please enter amount of numbers to be inputted: " );
// int num = int.Parse(Console.ReadLine());
// int[] numbers= new int [num];
// int length = numbers.Length;
// for(int i = 0;i < length;i++)
// {
//     Console.WriteLine("Enter index " + i);
//     numbers[i] = int.Parse(Console.ReadLine());
// }
// string response = $"{numbers[0]}";
// string response2 = "";
// for(int i = 1;i < numbers.Length+1;i++)
// {
//     if(numbers[i] == numbers[i - 1] )
//     {
//         response += numbers[i -1];
//     }
//     else{
//         if(response.Length > response2.Length)
//         {
//             response2 = response;
//             response = $"{numbers[i]}";
//         }
//     }
// }
// Console.WriteLine(response2);




// Console.Write("Please enter amount of numbers to be inputted: " );
// int num = int.Parse(Console.ReadLine());
// int[] numbers= new int [num];
// int length = numbers.Length;
// for(int i = 0;i < length;i++)
// {
//     Console.WriteLine("Enter index " + i);
//     numbers[i] = int.Parse(Console.ReadLine());
// }
// string response = "";
// string response2 = "";
// for(int i = 0;i < length-1 ;i++)
// {
//    if(numbers[i]+1 == numbers[i+1] )
//    {
//         response += numbers[i] ;
//         response +=  numbers[i+1];
//         if(numbers[i] == numbers[i+1])
//         {
//             response += numbers[i];
//         }
//    }
//    else
//    {
//         if(response.Length > response2.Length)
//         {
//             response2 = response;
//             response = $"{numbers[i]}";
//         }
//    }
// }
// Console.WriteLine(response2);





// Console.Write("Please enter amount of numbers to be inputted: " );
// int num = int.Parse(Console.ReadLine());
// int[] numbers= new int [num];
// int length = numbers.Length;
// for(int i = 0;i < length;i++)
// {
//     Console.WriteLine("Enter index " + i);
//     numbers[i] = int.Parse(Console.ReadLine());
// }
// string response = "";
// string response2 = "";
// for(int i = 0;i < length;i++)
// {
//     for(int j = 1;j < length;j++)
//     {
//         if(numbers[i] < numbers[j])
//     {
//         response += numbers[i];
//         break;
//     }
//     }
// }
// Console.WriteLine(response);