using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogger.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBlogger.Models;

namespace TheBlogger.Controllers
{
    public class AccountController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;


        public AccountController(IPostRepository postRepository, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _postRepository = postRepository;
            _signInManager = signInManager;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login obj)
        {
            if (ModelState.IsValid)
            {
                // Girilen kullanıcı adına sahip kullanıcı varse user değişkenine atıyoruz
                var user = await _userManager.FindByNameAsync(obj.username);

                // eğer kullanıcı varsa if içerisine giriyoruz
                if (user != null)
                {
                    // kullanıcı girişi yapıyoruz
                    var result = await _signInManager.PasswordSignInAsync(user, obj.password, false, false);

                    // eğer giriş ilemi başarılıysa anasayfaya yönlendiriyoruz
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                // böyle bir kullanıcı yoksa geriye hata döndürüyoruz
                // ilk parametre key ikinci parametre value
                ModelState.AddModelError("", "Kullanıcı adı veya Parola hatalı.");
                return View(obj);
            }
            return View(obj);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Login obj)
        {
            if (ModelState.IsValid)
            {
                // yeni bir kullanıcı nesnesi oluşturuyoruz
                var user = new IdentityUser()
                { UserName = obj.username };
                // oluşturulan kullanıcıyı parola(hash) ile birlikte kayıt ediyoruz
                var result = await _userManager.CreateAsync(user, obj.password);

                var isEmailAlreadyExists = _userManager.FindByNameAsync(obj.username);
                // kayıt işlemi başarılı ise Login sayfasına yönlendiriyoruz
                if (result.Succeeded)
                {
                    var result2 = await _signInManager.PasswordSignInAsync(user, obj.password, false, false);

                    // eğer giriş ilemi başarılıysa anasayfaya yönlendiriyoruz
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                if (isEmailAlreadyExists != null)
                {
                    ModelState.AddModelError("", "Kullanıcı adı zaten var");
                }


                return View(obj);
            }
            return View(obj);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}