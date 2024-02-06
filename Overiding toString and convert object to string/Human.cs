using System.Security.Cryptography;

public class Human
{
    public string name { get; set; }
    public int age {get; set;}

    public double height {get; set;}



    public void ConvertHUman()
    {   
        Console.WriteLine($"{name}\t\t{age}\t\t{height}");
    }

    public override string ToString()
    {
        return $"{name}**{age}**{height}";
    }

    public static string[] ConvertFileReadToStringArray(string arr)
    {
        return arr.Split("**");
    }

    public static object ConvertToObject(string[] arr)
    {
        Human newHuman = new Human();
        newHuman.name = arr[0];
        newHuman.age = int.Parse(arr[1]);
        newHuman.height = double.Parse(arr[2]);

        return newHuman;
    }
}