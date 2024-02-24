using EFPract.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Core.Apllication.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Drop(User user);
        User Update(User user);
        User Get(string email);
        List<User> GetAll();
        void Delete(User user);
    }
}
