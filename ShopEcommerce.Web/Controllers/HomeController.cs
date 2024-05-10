using AutoMapper;
using BotDetect.Web.Mvc;
using Shop.Data.Infastructure;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Infrastructure.Extensions;
using ShopEcommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShopEcommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productCategoryService;
        private IProductService _productService;
        private IContactService _contactService;
        private IUnitOfWork _unitOfWork;

        public HomeController(IProductCategoryService productCategoryService, IProductService productService, IContactService contactService, IUnitOfWork unitOfWork)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _contactService = contactService;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var hotProduct = _productService.GetHotProduct();
            var hotProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(hotProduct);
            var listProductCategory = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(listProductCategory);
            var homeViewModel = new HomeViewModel();
            homeViewModel.lastesProduct = hotProductViewModel;
            homeViewModel.latesProductCategory = listProductCategoryViewModel;
            return View(homeViewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidation("ContactCaptCha", "ContactCaptCha", "Mã xác nhận không hợp lệ")]
        public ActionResult Contact(ContactViewModel contactViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contact newContact = new Contact();
                    newContact.UpdateContact(contactViewModel);
                    newContact.Status = false;
                    newContact.CreateDate = DateTime.Now;
                    _contactService.Add(newContact);
                    _contactService.Save();
                    ViewData["SuccessMessage"] = "Send contact success";
                    newContact.Name = "";
                    newContact.Email = "";
                    newContact.PhoneNumber = 0;
                    newContact.Message = "";
                }
                else
                {
                    ModelState.AddModelError("Faild", "Gửi liên hệ không thành công ");
                }
            }
            catch (Exception ex)
            {
                //log
            }

            return View("Contact");
        }

        //[HttpPost]
        //public ActionResult SendContact(ContactViewModel contactViewModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Contact newContact = new Contact();
        //            newContact.UpdateContact(contactViewModel);
        //            _contactService.Add(newContact);
        //            _contactService.Save();
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("Faild", "Gửi liên hệ không thành công ");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //log
        //    }

        //    return View("Index");
        //}

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategory = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategory);
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = _productCategoryService.GetAll();
            var listproductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategorye>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listproductCategoryViewModel);
        }
    }
}