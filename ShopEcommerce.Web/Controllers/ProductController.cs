using AutoMapper;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Infrastructure.Core;
using ShopEcommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShopEcommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        private IProductTagService _productTagService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IProductTagService productTagService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _productTagService = productTagService;
        }

        public ActionResult Category(int id, int page = 1)
        {
            int pageSize = 20;
            int totaRow = 0;
            var productModel = _productService.GetProductByParentId(id, page, pageSize, out totaRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totaRow / pageSize);
            var category = _productCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<ProductCategorye, ProductCategoryViewModel>(category);
            var pageing = new Pagination<ProductViewModel>()
            {
                Items = productViewModel,
                Page = page,
                MaxPage = 5,
                TotalCount = totaRow,
                TotalPage = totalPage,
            };
            return View(pageing);
        }

        public ActionResult Detail(int id)
        {
            var inforProduct = _productService.GetById(id);
            var productModel = Mapper.Map<Product, ProductViewModel>(inforProduct);
            int idCategory = inforProduct.CategoryID;
            var listSame = _productService.GetSameInforProduct(idCategory);
            ViewBag.ListSame = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listSame);
            var listTagProduct = _productTagService.GetTagByID(id);
            ViewBag.ListTagProduct = Mapper.Map<IEnumerable<ProductTag>, IEnumerable<ProductTagViewModel>>(listTagProduct);
            return View(productModel);
        }

        public ActionResult ProductTag(string tagID)
        {
            var listproductByTag = _productService.GetListProductByTag(tagID);
            var listproductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listproductByTag);
            ViewBag.Tag = tagID;
            return View(listproductViewModel);
        }
    }
}