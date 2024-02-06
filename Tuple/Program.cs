using System.Collections;

Tuple<int, string, bool, Tuple<int, string>> tuple = new(2, "ade", true, Tuple.Create(2, "4"));
int a = tuple.Item1;
int b = tuple.Item4.Item1;

(int age,double amount)t1 = (2,4);


Console.WriteLine(Arithmetics(5,1,7));
static (int,double,int) Arithmetics(int a,int b,int c)
{
    int sum = a + b + c;
    double division = (a + c)/b;
    int multiplication = a * b * c;
    return (sum,division,multiplication);
}