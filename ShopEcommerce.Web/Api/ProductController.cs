using AutoMapper;
using Shop.Data.Infastructure;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Infrastructure.Core;
using ShopEcommerce.Web.Infrastructure.Extensions;
using ShopEcommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiController
    {
        private IProductService _productService;
        private IUnitOfWork _unitOfWork;

        public ProductController(IProductService productService, IUnitOfWork unitOfWork)
        {
            this._productService = productService;
            this._unitOfWork = unitOfWork;
        }

        [Route("getinfordetails/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetInforDetail(HttpRequestMessage reques, int id)
        {
            var model = _productService.GetById(id);
            var listProductViewModel = Mapper.Map<Product, ProductViewModel>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listProductViewModel);
            return respose;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage reques, string keyWord, int page, int pageSize = 10)
        {
            int totalRow = 0;
            var model = _productService.GetAll(keyWord);
            totalRow = model.Count();
            var query = model.OrderByDescending(x => x.Createdate).Skip(page * pageSize).Take(pageSize);
            var listProductViewModel = Mapper.Map<List<ProductViewModel>>(query.ToList());
            var pagin = new Pagination<ProductViewModel>()
            {
                Items = listProductViewModel,
                Page = page,
                TotalCount = totalRow,
                TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };
            var respose = reques.CreateResponse(HttpStatusCode.OK, pagin);
            return respose;
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage reques, ProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return reques.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                Product newProduct = new Product();
                newProduct.UpdateProduct(productViewModel);
                newProduct.CreareBy = User.Identity.Name;
                var model = _productService.Add(newProduct);
                _productService.Save();
                var resposeData = Mapper.Map<Product, ProductViewModel>(newProduct);
                return reques.CreateResponse(HttpStatusCode.OK, resposeData);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                // ghi log
            }
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage reques, ProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return reques.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                var productDb = _productService.GetById(productViewModel.ID);
                productDb.UpdateProduct(productViewModel);
                productDb.Createdate = DateTime.Now;
                productDb.UpdateBy = User.Identity.Name;
                _productService.Update(productDb);
                _productService.Save();
                return reques.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                // ghi log
            }
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage reques, int id)
        {
            try
            {
                var oldProduct = _productService.Delete(id);
                //_productService.Save();
                _unitOfWork.Commit();
                var respose = Mapper.Map<Product, ProductViewModel>(oldProduct);
                return reques.CreateResponse(HttpStatusCode.OK, respose);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}