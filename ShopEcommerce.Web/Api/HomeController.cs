using System.Web.Http;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiController
    {
        public HomeController()
        {
        }

        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello , BigBoss Shop Member";
        }
    }
}