using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public class UserInfoRepository :IUserInfoRepository
    {
        DBcontext _dBcontext;
        public UserInfoRepository(DBcontext dBcontext) {
            _dBcontext = dBcontext;
        }
            
        public bool userExist(Guid userId)
        {
            var user = _dBcontext.Users.FirstOrDefault(u => u.id == userId);
            return user != null;
        }

        public User getUser(Guid userId)
        {
           return _dBcontext.Users.FirstOrDefault(u => u.id == userId);
        }

        public IEnumerable<User> allUsers()
        {
            return _dBcontext.Users;
        }

        public void deleteUser(Guid userId)
        {
            var user = this.getUser(userId);
            _dBcontext.Users.Remove(user);
        }

        public void addUser(User user)
        {
            _dBcontext.Users.Add(user);
            _dBcontext.SaveChanges();
        }

        public void updateUser(User user)
        {
            _dBcontext.Users.Update(user);
        }

        public User getUserByEmail(string email)
        {
            User user = _dBcontext.Users.Where(u => u.email == email).FirstOrDefault();
            return user;
        }

        public void SaveAllNewChanges()
        {
            _dBcontext.SaveChanges();
        }
    }
}
