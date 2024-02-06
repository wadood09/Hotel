Lion lion = new Lion();
lion.Name = "Mufasa";
lion.Age = 3;
lion.Breed = "Desert breed";
Console.WriteLine(lion.Name);
Console.WriteLine(lion.Age);
Console.WriteLine(lion.Breed);
public class Parentclass
{
    protected int num = 10;
    protected void ParentMethod()
    {
        Console.WriteLine("This is parent method");
    }
}
public class Childclass : Parentclass
{
    public void ChildMethod()
    {
        int childNum = num;
        Console.WriteLine($"The child number is {childNum}");
        ParentMethod();
    }
}



public class Human
{
    public string name;
    public int age;
    public int height;
    public void Sleep()
    {
        Console.WriteLine("Zzz");
    }
}


public class Lion
{
    private string name;
    private int age;
    private string breed;
    public string Name
    {
        set { name = value; }
        get { return name; }
    }
    public int Age
    {
        set
        {
            age = value;
            if (age < 5)
            {
                Console.WriteLine("Age is less than 5");
            }
            else
            {
                age = value;
            }
        }
        get { return age; }
    }
    public string Breed
    {
        set { breed = value; }
        get { return breed; }
    }
    // public void AccessValue(string Name, int Age, string Breed)
    // {
    //     name = Name;
    //     age = Age;
    //     breed = Breed;
    //     Console.WriteLine($"{Name} is {Age} years old,a breed from the {Breed}");
    //     Console.WriteLine($"{Name} roar like storm");
    // }
    // public void Roar()
    // {
    //     Console.WriteLine($"{name} is {age} years old,a breed from the {breed}");
    //     Console.WriteLine($"{name} roar like storm");
    //     Console.WriteLine("roar like storm");
    // }
}