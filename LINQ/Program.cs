// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
List<int> list = new() { 11, 8, -2, 9, 12, 1, -6, -13, -9 };

var evenWithQuerySyntax = from num in list
                          where num % 2 == 0 || num > 10
                          select num;
                          
var average = (from num in list
               where num % 2 == 0 && num < 0 || num % 2 != 0 && num > 0
               select num).Average();

var average2 = list.Where(b => b % 2 == 0 && b < 0 || b % 2 != 0 && b > 0).Average();
Console.WriteLine(average2);