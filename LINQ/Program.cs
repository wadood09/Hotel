// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<int> list = new() { 11, 8, 2, 9, 12, 1 };

var evenQuerySyntax = from num in list
                      where num % 2 == 0 || num > 10
                      select num;
foreach (var num in evenQuerySyntax)
{
    Console.WriteLine(num);
}