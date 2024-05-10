using Microsoft.AspNet.Identity.Owin;
using ShopEcommerce.Web.App_Start;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string email, string passWord, bool remenberMe)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, change to shouldLockout: true
                    var result = await SignInManager.PasswordSignInAsync(email, passWord, remenberMe, shouldLockout: false);
                    return request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}