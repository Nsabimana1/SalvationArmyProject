using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalvationArmyProject.Models;

namespace SalvationArmyProject.SeedData
{
    public class UserDummyData
    {
        public static UserDummyData Current { get; } = new UserDummyData();
        public List<UserDto> users { get; set; }

        public UserDummyData() {
            users = new List<UserDto>()
            {
                new UserDto()
                {
                    id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    firstName = "ab",
                    lastName = "cd",
                    birthDate = new DateTime(),
                    email = "ab@gmail.com",
                    phoneNumber = "0787456789",
                    userPrivilage = "standard"

                },
                new UserDto()
                {
                    id = new Guid("0f8fad5b-d9cb-469f-a265-70867728950e"),
                    firstName = "ab",
                    lastName = "cd",
                    birthDate = new DateTime(),
                    email = "ab@gmail.com",
                    phoneNumber = "0787456789",
                    userPrivilage = "standard"

                },
                new UserDto()
                {
                    id = new Guid("0f8fad5b-d9cb-469f-a365-70867728950e"),
                    firstName = "ab",
                    lastName = "cd",
                    birthDate = new DateTime(),
                    email = "ab@gmail.com",
                    phoneNumber = "0787456789",
                    userPrivilage = "standard"

                },
                new UserDto()
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
        }
    }
}
