// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Generic<string,int> generic = new();
sealed class Sealed
{
    // Can be instantiated but can't be inherited
}
static class Static
{
    // Can only contain static fields e.g the Math in-built class
    // Can't be instantiated
}
abstract class Abstract
{
    // Can't be instantiated.Can only be inherited
    // Implementation is done in child class through overide and new keyword and overloading it
}
partial class Partial
{
    // This allows multiples classes with the same name to exist
    // This allows same classes to exist in different files
}

// Generic Class
public class Generic<D,P,H,K,Y>
{
    public K Content {get; set;}
    public D Age {get; set;}
    public P Name {get; set;}
    public H School {get; set;}
    public P Teacher {get; set;}
}
