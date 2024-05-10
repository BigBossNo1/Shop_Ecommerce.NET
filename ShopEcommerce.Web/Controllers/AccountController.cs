using BotDetect.Web;
using BotDetect.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shop.Common;
using Shop.Models.Models;
using ShopEcommerce.Web.App_Start;
using ShopEcommerce.Web.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopEcommerce.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [CaptchaValidation("LoginCaptcha", "LoginCaptcha", "Mã xác nhận không hợp lệ")]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra mã captcha
                string userEnteredCaptcha = HttpContext.Request.Form["LoginCaptcha"];
                bool isCaptchaValid = new Captcha("LoginCaptcha").Validate(userEnteredCaptcha);

                if (!isCaptchaValid)
                {
                    ModelState.AddModelError("", "Mã xác nhận không đúng.");
                    return View(model);
                }
                ApplicationUser user = _userManager.Find(model.UserName, model.PassWord);
                if (user != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                    ClaimsIdentity identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = model.RememberMe;
                    authenticationManager.SignIn(props, identity);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return RedirectToAction(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("RegisterCaptcha", "RegisterCaptcha", "Mã xác nhận không hợp lệ")]
        public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
        {
            var userEmail = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (userEmail != null)
            {
                ModelState.AddModelError(registerViewModel.Email, "Email đã tồn tại");
                return View(registerViewModel);
            }
            var userName = await _userManager.FindByNameAsync(registerViewModel.UserName);
            if (userName != null)
            {
                ModelState.AddModelError(registerViewModel.UserName, "Tên đăng nhập đã tồn tại");
                return View(registerViewModel);
            }

            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser()
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    FullName = registerViewModel.FullName,
                    PhoneNumber = registerViewModel.PhoneNumber
                };

                await _userManager.CreateAsync(newUser, registerViewModel.PassWord);
                var adminUser = await _userManager.FindByEmailAsync(registerViewModel.Email);
                if (adminUser != null)
                {
                    await _userManager.AddToRolesAsync(adminUser.Id, new string[] { "User" });
                }

                ViewData["SuccessMessage"] = "Đăng ký thành công ";
                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/Client/template/RegisterContent.html"));
                content = content.Replace("{{Name}}", registerViewModel.UserName);
                content = content.Replace("{{Email}}", registerViewModel.Email);
                content = content.Replace("{{PhoneNumber}}", registerViewModel.PhoneNumber);

                MailHelper.SendMail(registerViewModel.Email, "Thông tin đăng ký ", content);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}