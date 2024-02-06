// See https://aka.ms/new-console-template for more information
using System;
using AdoClass;

var obj = new StudentManager();
int choice = int.Parse(Console.ReadLine());
switch(choice)
{
    case 1 :
    Console.WriteLine("Enter your name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter your Address");
    string address = Console.ReadLine();
    Console.WriteLine("Enter your email");
    string email = Console.ReadLine();
    Console.WriteLine("Enter your age");
    int age = int.Parse(Console.ReadLine());
    obj.AddStudent(new Student(name,age,email,address));
    break;
    case 2 :
    Console.WriteLine("Enter your Id");
    int id = int.Parse(Console.ReadLine());
    obj.DeleteStudent(id);
    break;
    case 3 :
    Console.WriteLine(String.Join(","  , obj.GetAllStudents()));
    break;
    case 4 :
    Console.WriteLine("Enter your Id");
    int studentId = int.Parse(Console.ReadLine()!);
    Console.WriteLine(obj.GetStudent(studentId));
    break;
    case 5 :
    Console.WriteLine("Enter your Id");
    int stdentId = int.Parse(Console.ReadLine()!);
    Console.WriteLine("Enter your Name");
    string stdName = Console.ReadLine()!;
    obj.UpdateStudent(stdentId , stdName);
    break;
    default :
    Console.WriteLine("Invalid Input!!");
    break;
    
}




