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
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager,MyECommerceContext myECommerceContext,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _myECommerceContext = myECommerceContext;
            _signInManager = signInManager;
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

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var login = await _userManager.FindByNameAsync(loginVM.UserName);

                if (login!=null)
                {
                    var result = await _signInManager.PasswordSignInAsync(login, loginVM.Password, false, false);
                    if (result.Succeeded) 
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        return View(loginVM);
                    }
                    
                }
                else 
                { 
                    return View() ;
                }

            }
            else
            {
                return View(loginVM);
            }
        }


    }
}
