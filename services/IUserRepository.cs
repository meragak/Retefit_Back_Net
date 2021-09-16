using Retfeet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retfeet.API.services
{
    public interface IUserRepository
    {

        public IEnumerable<Users> GetUsers();
        public Users GetUser(int id);
        public void addUser(Users user);

        public void updateUser(Users user);
        public void deleteUser(Users user);
        public bool userExits(Users user);
        public void saveChanges();




    }
}
