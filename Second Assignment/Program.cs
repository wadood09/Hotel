// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello User!");
Console.WriteLine("Enter amount of dog details to be printed");
int amount = int.Parse(Console.ReadLine());
Dog[] dogs = new Dog[amount];
for(int i = 0;i < amount;i++)
{
    Console.WriteLine($"Entering details of dog {i+1}");
    var dogDetails = GetDetailsOfDog();
    dogs[i] = new Dog
    {
        Name = dogDetails.Item1,
        Colour = dogDetails.Item2,
        Age = dogDetails.Item3,
        Breed = dogDetails.Item4
    };
    Console.WriteLine();
}
foreach (var dog in dogs)
{
    Console.WriteLine($"\nThe name of this dog is {dog.Name},it is {dog.Age} years old.It is {dog.Colour} in colour and it is a {dog.Breed}");
    Console.WriteLine($"{dog.Name},say Hi!!!");
    dog.Sound();
    Console.WriteLine();
}

static (string, string, int, string) GetDetailsOfDog()
{
    Console.WriteLine("Enter name of dog: ");
    string name = Console.ReadLine();
    Console.WriteLine("Enter colour of the dog: ");
    string colour = Console.ReadLine();
    Console.WriteLine("Enter age of dog: ");
    int age = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter type of breed of dog: ");
    string breed = Console.ReadLine();
    return (name, colour, age, breed);
}


public class Dog
{
    private string name;
    private string colour;
    private int age;
    private string breed;
    public string Name
    {
        set { name = value; }
        get { return name; }
    }
    public string Colour
    {
        set { colour = value; }
        get { return colour; }
    }
    public int Age
    {
        set { age = value; }
        get { return age; }
    }
    public string Breed
    {
        set { breed = value; }
        get { return breed; }
    }
    public void Sound()
    {
        Console.WriteLine("Woof!!! Woof!!!");
    }
}
