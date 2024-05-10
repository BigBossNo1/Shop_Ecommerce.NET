using AutoMapper;
using Shop.Common;
using Shop.Data.Infastructure;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Infrastructure.Extensions;
using ShopEcommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopEcommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;
        private IOrderDetailsService _orderDetailsService;
        private IUnitOfWork _unitOfWork;

        public CartController(IProductService productService, IOrderService orderService, IOrderDetailsService orderDetailsService, IUnitOfWork unitOfWork)
        {
            this._productService = productService;
            this._orderService = orderService;
            this._orderDetailsService = orderDetailsService;
            this._unitOfWork = unitOfWork;
        }

        public ActionResult CartDetail()
        {
            var list = (List<CartViewModel>)Session[CommonConstants.SessionCart];

            // Kiểm tra nếu list chưa tồn tại, hãy tạo mới
            if (list == null)
            {
                list = new List<CartViewModel>();
                Session[CommonConstants.SessionCart] = list;
            }

            return View(list);
        }

        // [HttpPost]
        public ActionResult Add(int productID)
        {
            var cart = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            var product = _productService.GetById(productID);
            if (cart == null)
            {
                cart = new List<CartViewModel>();
            }
            if (product.Quantity == 0)
            {
                return Json(new
                {
                    status = false,
                    message = "Sản phẩm này hiện đang hết hàng"
                });
            }
            if (cart.Any(x => x.ProductID == productID))
            {
                foreach (var item in cart)
                {
                    if (item.ProductID == productID)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                CartViewModel newItem = new CartViewModel();
                newItem.ProductID = productID;
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }

            Session[CommonConstants.SessionCart] = cart;
            return RedirectToAction("CartDetail");
        }

        //
        [HttpPost]
        public JsonResult Update(string cartData)
        {
            try
            {
                var cartClien = new JavaScriptSerializer().Deserialize<List<CartViewModel>>(cartData);
                var cartSession = (List<CartViewModel>)Session[CommonConstants.SessionCart];
                foreach (var item in cartSession)
                {
                    foreach (var jItem in cartClien)
                    {
                        if (item.ProductID == jItem.ProductID)
                        {
                            item.Quantity = jItem.Quantity;
                        }
                    }
                }

                Session[CommonConstants.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine(ex.Message);

                return Json(new
                {
                    status = false,
                    error = ex.Message
                });
            }
        }

        [HttpPost]
        public ActionResult DeleteAll()
        {
            Session[CommonConstants.SessionCart] = new List<CartViewModel>();
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteById(int productId)
        {
            try
            {
                var cartSession = (List<CartViewModel>)Session[CommonConstants.SessionCart];
                var itemToRemove = cartSession.FirstOrDefault(item => item.ProductID == productId);

                if (itemToRemove != null)
                {
                    cartSession.Remove(itemToRemove);
                    Session[CommonConstants.SessionCart] = cartSession;
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        error = "Product not found in the cart."
                    });
                }
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine(ex.Message);

                return Json(new
                {
                    status = false,
                    error = ex.Message
                });
            }
        }

        public ActionResult Payment()
        {
            // Lấy giá trị amount từ query string
            var amount = Request.QueryString["amount"];
            ViewBag.TotalAmout = amount;
            // Truyền giá trị amount đến view hoặc thực hiện các xử lý thanh toán khác
            var list = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            // Kiểm tra nếu list chưa tồn tại, hãy tạo mới
            if (list == null)
            {
                list = new List<CartViewModel>();
                Session[CommonConstants.SessionCart] = list;
            }
            ViewBag.ListOrder = list;
            return View();
        }

        [HttpPost]
        public ActionResult Order(OrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                Order newOrder = new Order();
                newOrder.UpdateOrder(model);
                newOrder.CreateDate = DateTime.Now;
                newOrder.CreateBy = "ToanLV";
                newOrder.PaymentMethod = "Thanh toán khi nhận hàng";
                newOrder.PaymentStatuss = "Chưa thanh toán";
                newOrder.Statuss = true;
                _orderService.Add(newOrder);
                _unitOfWork.Commit();
                var list = (List<CartViewModel>)Session[CommonConstants.SessionCart];
                foreach (var item in list)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.OrderID = newOrder.ID;
                    orderDetails.ProductID = item.ProductID;
                    orderDetails.Quantity = item.Quantity;
                    _orderDetailsService.Add(orderDetails);
                    _unitOfWork.Commit();
                }
                ViewData["SuccessMessage"] = "success";
                Session[CommonConstants.SessionCart] = null;
            }
            catch (Exception ex)
            {
                //log
            }
            return View("OrderSuccess");
        }

        public ActionResult OrderSuccess(OrderViewModel model)
        {
            return View();
        }
    }
}