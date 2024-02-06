// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello User!");
Address myAddress = new()
{
    City = "Abeokuta",
    State = "Ogun State",
    Country = "Nigeria"
};
foreach (var day in Enum.GetValues(typeof(DaysOfTheWeek)))
{
    Console.WriteLine((int)day +  ". " + day);
}

var a = typeof(int);

