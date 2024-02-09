// See https://aka.ms/new-console-template for more information
using GenericPrinter;

var paper = new Sunrise();
var printer = new GenericLaserPrinter<Sunrise>(paper);
printer.Print("This introduction to Generics");
printer.Display();