using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.SeedData
{
    public static class UserInfoContextExtension
    {
        public static void EnsureSeedDataForContext(this DBcontext context)
        {
            //public static void EnsureSeedDataForContext(this DBcontext context) {
            if (context.Users.Any()) {
                return;
            }

            var users = new List<User>()
            {
                new User()
                {
                    id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    firstName = "ab",
                    lastName = "cd",
                    birthDate = new DateTime(),
                    email = "ab@gmail.com",
                    phoneNumber = "0787456789",
                    userPrivilage = "standard"

                },
                new User()
                {
                    id = new Guid("0f8fad5b-d9cb-469f-a265-70867728950e"),
                    firstName = "ab",
                    lastName = "cd",
                    birthDate = new DateTime(),
                    email = "ab@gmail.com",
                    phoneNumber = "0787456789",
                    userPrivilage = "standard"

                },
                new User()
                {
                    id = new Guid("0f8fad5b-d9cb-469f-a365-70867728950e"),
                    firstName = "ab",
                    lastName = "cd",
                    birthDate = new DateTime(),
                    email = "ab@gmail.com",
                    phoneNumber = "0787456789",
                    userPrivilage = "standard"

                },
                new User()
                {
                    id = new Guid("0f8fad5b-d9cb-469f-a465-70867728950e"),
                    firstName = "ab",
                    lastName = "cd",
                    birthDate = new DateTime(),
                    email = "ab@gmail.com",
                    phoneNumber = "0787456789",
                    userPrivilage = "standard"

                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
