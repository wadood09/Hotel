// See https://aka.ms/new-console-template for more information
using DapperClass;
Console.WriteLine("Hello, World!");
IStudentManager studentManager = new StudentManager();
// studentManager.Create(new Student{Email = "ade@email.com" , Name = "ade"});
// Console.WriteLine(String.Join(',', studentManager.GetAll()));
Console.WriteLine(studentManager.Get(1));