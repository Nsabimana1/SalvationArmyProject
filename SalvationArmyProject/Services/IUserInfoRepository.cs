using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Services
{
    public interface IUserInfoRepository
    {
        bool userExist(Guid userId);
        User getUser(Guid userId);
        IEnumerable<User> allUsers();
        void deleteUser(Guid userId);
        void addUser(User user);
        void updateUser(User user);
    }
}
