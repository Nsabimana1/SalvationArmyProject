using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalvationArmyProject.Models;
using SalvationArmyProject.Services;

namespace SalvationArmyProject.Controllers
{
    public class UserController : Controller
    {
        IUserInfoRepository _userInfoRepository;

        public UserController(IUserInfoRepository userInfoRepository) {
            this._userInfoRepository = userInfoRepository;
        }

        [HttpGet("/user/all")]
        public IActionResult GetAllUsers() {
            // var result = Mapper.Map<IEnumerable<UserDto>>(_userInfoRepository.allUsers());
            return Ok(_userInfoRepository.allUsers());
        }

        [HttpGet("/user/{userId}")]
        public IActionResult GetUser(Guid userId)
        {
            if (_userInfoRepository.userExist(userId))
            {
                return Ok(_userInfoRepository.getUser(userId));
            }
            else {
                return NotFound();
            }
        }
    }
}
