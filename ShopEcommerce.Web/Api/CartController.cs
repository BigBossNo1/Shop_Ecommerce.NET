using AutoMapper;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private IOrderService _orderService;
        private IOrderDetailsService _orderDetailService;

        public CartController(IOrderService orderService, IOrderDetailsService orderDetailsService)
        {
            this._orderService = orderService;
            this._orderDetailService = orderDetailsService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage reques, bool status)
        {
            var model = _orderService.GetAllByStatus(status);
            var listOrderViewModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listOrderViewModel);
            return respose;
        }

        [Route("getallByStatus")]
        [HttpGet]
        public HttpResponseMessage GetAllByStatus(HttpRequestMessage reques, bool status)
        {
            var model = _orderService.GetAllByStatus(status);
            var listOrderViewModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listOrderViewModel);
            return respose;
        }

        [Route("getInformationCustomer")]
        [HttpGet]
        public HttpResponseMessage GetinformationCustomer(HttpRequestMessage reques, int id)
        {
            var model = _orderService.GetById(id);
            var informationCustomer = Mapper.Map<Order, OrderViewModel>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, informationCustomer);
            return respose;
        }

        [Route("updateStatus")]
        [HttpGet]
        public HttpResponseMessage UpdateStatus(HttpRequestMessage reques, int id)
        {
            try
            {
                var order = _orderService.GetById(id);
                order.Statuss = false;
                _orderService.Update(order);
                return reques.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                // ghi log
            }
        }

        [Route("getdetail")]
        [HttpGet]
        public HttpResponseMessage GetDetail(HttpRequestMessage reques, int id)
        {
            try
            {
                var model = _orderDetailService.GetDetailByID(id);
                var listOrderDetailViewModel = Mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsViewModel>>(model);
                var respose = reques.CreateResponse(HttpStatusCode.OK, listOrderDetailViewModel);
                return respose;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}