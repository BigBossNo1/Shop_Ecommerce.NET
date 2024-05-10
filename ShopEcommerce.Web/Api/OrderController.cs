using AutoMapper;
using Shop.Data.Infastructure;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private IOrderService _orderService;
        private IUnitOfWork _unitOfWork;

        public OrderController(IOrderService orderService, IUnitOfWork unitOfWork)
        {
            this._orderService = orderService;
            this._unitOfWork = unitOfWork;
        }

        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetAll(string keyWord)
        {
            var model = _orderService.GetAll(keyWord);
            var listOrderViewModel = Mapper.Map<List<OrderViewModel>>(model.ToList());
            return Ok(listOrderViewModel);
        }

    }
}