using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalvationArmyProject.Entities;
using SalvationArmyProject.Services;
using SalvationArmyProject.ViewModels;

namespace SalvationArmyProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private IUserInfoRepository _userInfoRepository;
        private IEventRequestRepository _iEventRequestRepository;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IUserInfoRepository userInfoRepository,
            IEventRequestRepository iEventRequestRepository
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._userInfoRepository = userInfoRepository;
            this._iEventRequestRepository = iEventRequestRepository;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    // use same id as the id in the aspnetusers table
                    await signInManager.SignInAsync(user, isPersistent: false);
                    var registeredUser = new User()
                    {
                        id = new Guid(),
                        email = model.Email
                    };
                    _userInfoRepository.addUser(registeredUser);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout() {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded) {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpGet("/Account/Profile/{email}")]
        public IActionResult Profile(string email)
        {
            var user = _userInfoRepository.getUserByEmail(email);
            IEnumerable<EventResponse> resp = _iEventRequestRepository.getRequestResponsesByUser(user.id);
            ProfileViewModelReturn model = new ProfileViewModelReturn();
            model.currentUser = user;
            model.userResponces = resp;
            return View(model);
        }

        [HttpPost("/Account/Profile")]
        public IActionResult Profile([FromForm] ProfileViewModelReturn model){
            if (ModelState.IsValid)
            {
                var user = _userInfoRepository.getUser(model.currentUser.id);
                if (user != null) {
                    _userInfoRepository.updateUser(user);
                    user.id = model.currentUser.id;
                    user.firstName = model.currentUser.firstName;
                    user.lastName = model.currentUser.lastName;
                    user.email = model.currentUser.email;
                    user.birthDate = model.currentUser.birthDate;
                    _userInfoRepository.SaveAllNewChanges();
                }
                return RedirectToAction("index", "home");
            }
            else {
                return View(model);
            }
        }
    }
}
