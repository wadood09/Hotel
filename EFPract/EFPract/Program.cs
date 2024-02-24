// See https://aka.ms/new-console-template for more information

using EFPract.Core.Apllication.Interfaces.Repositories;
using EFPract.Core.Domain.Entities;
using EFPract.Infrastructure.Repositories;

var user = new User
{
    Address = "abk",
    Email = "ade@gmail.com",
    FirstName = "Ola",
    LastName = "Ade",
    Gender = EFPract.Core.Domain.Enums.Gender.Male,
    Password = "pass",
    PhoneNumber = "091788",
    UserName = "Prosper",
    Role = "Student",
};

IUserRepository repo = new UserRepository();
repo.Drop(user);
