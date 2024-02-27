using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentFile_Project.Model.Enum;

namespace StudentFile_Project.Model.Entities
{
    public class User : BaseEntities
    {
        public string UserName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PassWord { get; set; } = default!;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; } = default!;
        public static User LoggedInUser{get;set;} = default!;
        //     public  override string ToString()
        // {
        //     return $"{Id}\t{FirstName}\t{LastName}\t{UserName}\t{Email}\t{PassWord}\t{Age}\t{Gender}\t{Role}";
        // }
        // public User(string userName, string email, string firstName, string lastName, string password, int age, Gender gender, string role)
        // {
        //     UserName = userName;
        //     FirstName = firstName;
        //     Email = email;
        //     LastName = lastName;
        //     PassWord = password;
        //     Age = age;
        //     Gender = gender;
        //     Role = role;
        // }
        // public User ToExam(string str)
        // {
        //     var model = str.Split('\t');
        //     return new User()
        //     {
        //         Id = model[0],
        //         FirstName = model[1],
        //         LastName = model[2],
        //         UserName = model[3],
        //         Email = model[4],
        //         PassWord = model[5],
        //         Age = int.Parse(model[6]),
        //         Gender = (Gender)Enum.Parse(typeof(Gender), model[7], true)

        //     };
        // }
    }


}