// See https://aka.ms/new-console-template for more information
using My_File_Project.Menu;

Console.WriteLine("Hello, World!");
OnStart onStart = new();
onStart.Check();
Menu menu = new();
menu.MainMenu();