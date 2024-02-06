using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
P
namespace AdoClass
{
    public class Student
    {

        public Student(string name, int age, string email, string address)
        {
            
            Name = name;
            Age = age;
            Email = email;
            Address = address;
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