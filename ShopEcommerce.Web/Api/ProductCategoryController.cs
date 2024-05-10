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
using System.Web.Script.Serialization;

namespace ShopEcommerce.Web.Api
{
    [RoutePrefix("api/productcategory")]
    [Authorize]
    public class ProductCategoryController : ApiController
    {
        private IProductCategoryService _productCategoryService;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryController(IProductCategoryService productCategoryService, IUnitOfWork unitOfWork)
        {
            this._productCategoryService = productCategoryService;
            this._unitOfWork = unitOfWork;
        }

        [Route("getparentid")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage reques)
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listProductCategoryViewModel);
            return respose;
        }

        [Route("getidinfor/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetIdInfor(HttpRequestMessage reques, int id)
        {
            var model = _productCategoryService.GetById(id);
            var listProductCategoryViewModel = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(model);
            var respose = reques.CreateResponse(HttpStatusCode.OK, listProductCategoryViewModel);
            return respose;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage reques, string keyWord, int page, int pageSize = 10)
        {
            int totalRow = 0;
            var model = _productCategoryService.GetAll(keyWord);
            totalRow = model.Count();
            var query = model.OrderByDescending(x => x.Createdate).Skip(page * pageSize).Take(pageSize);
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(query);
            var pagin = new Pagination<ProductCategoryViewModel>()
            {
                Items = listProductCategoryViewModel,
                Page = page,
                TotalCount = totalRow,
                TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
            };
            var respose = reques.CreateResponse(HttpStatusCode.OK, pagin);
            return respose;
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Add(HttpRequestMessage reques, ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return reques.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var productCategory = new ProductCategorye();
                    productCategory.UpdateProductCategory(productCategoryViewModel);
                    _productCategoryService.Add(productCategory);
                    _unitOfWork.Commit();
                    var resposeData = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(productCategory);
                    return reques.CreateResponse(HttpStatusCode.Created, resposeData);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                //  log
            }
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage reques, ProductCategoryViewModel productCategoryViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return reques.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var productCategory = _productCategoryService.GetById(productCategoryViewModel.ID);
                    productCategory.UpdateProductCategory(productCategoryViewModel);
                    _productCategoryService.Update(productCategory);
                    _unitOfWork.Commit();
                    var resposeData = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(productCategory);
                    return reques.CreateResponse(HttpStatusCode.OK, resposeData);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                // log
            }
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage reques, int id)
        {
            try
            {
                var oldProductCategory = _productCategoryService.Delete(id);
                _unitOfWork.Commit();
                var responData = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(oldProductCategory);
                return reques.CreateResponse(HttpStatusCode.OK, responData);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                // log
            }
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage reques, string checkProductCategory)
        {
            try
            {
                var listProductCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkProductCategory);
                foreach (var item in listProductCategory)
                {
                    var oldProductCategory = _productCategoryService.Delete(item);
                }
                _unitOfWork.Commit();
                return reques.CreateResponse(HttpStatusCode.OK, listProductCategory.Count());
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                // log
            }
        }
    }
}