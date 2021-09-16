using Retfeet.API.services;
using Retfeet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retfeet.API.services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyTechContext _context;
        public UserRepository(MyTechContext context)
        {
            _context = context;
        }
        void IUserRepository.addUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        void IUserRepository.deleteUser(Users user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        Users IUserRepository.GetUser(int id)
        {
            Users _user = _context.Users.FirstOrDefault(m => m.UserId == id);
            return _user;
        }

        IEnumerable<Users> IUserRepository.GetUsers()
        {
            return _context.Users.ToList();
        }

        void IUserRepository.updateUser(Users user)
        {
            _context.Users.Update(user);
            
        }
        bool IUserRepository.userExits(Users user)
        {
            Users _user = _context.Users.FirstOrDefault(m => m.Email == user.Email);
            if (_user != null)
            {
                return true;
            }
            return false;

        }
        void IUserRepository.saveChanges()
        {
            _context.SaveChanges();
        }
    }
}
