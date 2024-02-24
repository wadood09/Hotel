using EFPract.Core.Apllication.Interfaces.Repositories;
using EFPract.Core.Domain.Entities;
using EFPract.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPract.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        StudContext _context = new StudContext();
        public void Delete(User user)
        {
            _context.Set<User>().Remove(user);

        }

        public User Drop(User user)
        {
            _context.Set<User>().Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Get(string email)
        {
            var user = _context.Set<User>().SingleOrDefault(x => x.Email == email);
            return user;
        }

        public List<User> GetAll()
        {
            return _context.Set<User>().ToList();
        }

        public User Update(User user)
        {
            _context.Set<User>().Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
