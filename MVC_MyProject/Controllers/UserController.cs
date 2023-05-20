using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_MyProject.Models.ViewModels;
using MyECommerce.DAL.Context;
using MyECommerce.Entity.Entity;

namespace MVC_MyProject.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MyECommerceContext _myECommerceContext;

        public UserController(UserManager<AppUser> userManager,MyECommerceContext myECommerceContext)
        {
            _userManager = userManager;
            _myECommerceContext = myECommerceContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user=new AppUser();

                user.UserName = registerVM.Username;
                user.Email = registerVM.Email;

                var result = await _userManager.CreateAsync(user, registerVM.ConfirmPassword);

                if (result.Succeeded) 
                {   
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View(registerVM);
                }

            }
            else { return View(registerVM); }
        }
    }
}
