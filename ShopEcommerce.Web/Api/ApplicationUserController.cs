using AutoMapper;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/applicationuser")]
    public class ApplicationUserController : ApiController
    {
        private IApplicationUserService _applicationUserService;

        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            this._applicationUserService = applicationUserService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage reques)
        {
            var model = _applicationUserService.GetAll();
            var listUser = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listUser);
            return respose;
        }

        //[Route("update")]
        //[HttpPost]
        //public HttpResponseMessage Update(HttpRequestMessage reques, ApplicationUserViewModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return reques.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        var userDB = _applicationUserService.GetById(model.Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        // log
        //    }
        //}
    }
}