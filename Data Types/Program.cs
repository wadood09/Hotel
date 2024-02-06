// See https://aka.ms/new-console-template for more information
using System;
namespace DataType
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wadood");
            // sbyte a = 127;
            // Console.WriteLine(a);
            // int alpha =(int)'A';
            // int alpha2 =(int)'a';
            // Console.WriteLine(alpha);
            // Console.WriteLine(alpha2);
            // object name = "Ade";
            // object x = 20;
            // Console.WriteLine($"{name} {x}");
            // Console.WriteLine(byte.MinValue);
            // Console.WriteLine(byte.MaxValue);
            // Console.WriteLine(short.MaxValue);
            // Console.WriteLine(short.MinValue);
            // float y = 10.1f/3;
            // double z = y;
            // Console.WriteLine(z);
            // int x = 500;
            // int y = 1000;
            // bool result = x == y;
            // Console.WriteLine(result);
            // int? x = null;
            // Console.WriteLine(x);
            // int? y = 10;
            // int? z = y;
            // Console.WriteLine(z);
            // int a = 10;
            int? b = null;
            // Console.WriteLine(b);
            Console.WriteLine(b.HasValue);
            // Console.WriteLine(b.Value);
            Console.WriteLine(b.GetValueOrDefault());
        }
    }
}
