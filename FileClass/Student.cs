using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileClass
{
    public class Student
    {
        public static IList<Student> Students = new List<Student>();

        public Student(string name, int age, string email, string address)
        {
            
            Name = name;
            Age = age;
            Email = email;
            Address = address;
            this.Id = Students.Count + 1;
        }

        public int Id {get;set;}
        public string Name {get;set;}
        public int Age {get;set;}
        public string Email {get;set;}
        public string Address {get;set;}
        
        public  override string ToString()
        {
            return $"{Name}\t{Email}\t{Address}\t{Age}\t{Id}";
        }
    }
}