// See https://aka.ms/new-console-template for more information
// GreetingsDelegate[] greetingsDelegate = new GreetingsDelegate[2];
// greetingsDelegate[0] = Greetings;
// greetingsDelegate[1] = GreetingsWithName;
// List<GreetingsDelegate> delegates =  new();

GreetingsDelegate greetingsDelegate =Greetings;
greetingsDelegate += GreetingsWithName;
greetingsDelegate -= Greetings;
greetingsDelegate();

GreetingsDelegate anonymous = delegate ()
{
    Console.WriteLine("Good Morning");
};

Action anonymous2 = delegate ()
{
    Console.WriteLine("Good Morning");
};

Func<string> anonymous3 = delegate ()
{
    return "Good Morning";
};

GreetingsDelegate greetingsDelegate2 = Findsum;
greetingsDelegate2();

AreaDelegate rectangleArea = GetAreaOfRectangle;
Console.WriteLine("The area of rectangle is " + rectangleArea(5, 10));

AreaDelegate parallelogramArea = GetAreaOfParallelogram;
Console.WriteLine("The area of parallelogram is " + parallelogramArea(13, 9));

TransformDelegate transform = TakeToUpper;
string text = "this is an upper case statement";
TransformText(text, transform);

RoundDelegate difference = Math.Round;
Console.WriteLine(Difference(5.89, difference));





static double Difference(double num, RoundDelegate wholeNum)
{
    double rounded = wholeNum(num);
    return 10 - rounded;
}

static void TransformText(string text, TransformDelegate transform)
{
    var transformed = transform(text);
    Console.WriteLine(transformed);
}

static string TakeToUpper(string text)
{
    return text.ToUpper();
}

static string TakeToLower(string text)
{
    return text.ToLower();
}

static void Greetings()
{
    Console.WriteLine("Good Morning");
}
static string Greetings2() => "Good Morning";

static void GreetingsWithName()
{
    Console.Write("Enter name: ");
    string name = Console.ReadLine();
    Console.WriteLine($"Good Morning {name}");
}

static void Findsum()
{
    Console.Write("Enter first number: ");
    int firstNum = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int secondNum = int.Parse(Console.ReadLine());
    Console.WriteLine($"Their sum is {firstNum + secondNum}");
}

static double GetAreaOfRectangle(double length, double breadth)
{
    double area = length * breadth;
    return area;
}
static double GetAreaOfParallelogram(double height, double basse)
{
    double area = height * basse;
    return area;
}

delegate double AreaDelegate(double length, double breadth);
delegate void GreetingsDelegate();
delegate string TransformDelegate(string input);
delegate double RoundDelegate(double input);