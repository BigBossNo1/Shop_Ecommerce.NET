using Shop.Models.Models;
using ShopEcommerce.Web.Models;

namespace ShopEcommerce.Web.Infrastructure.Extensions
{
    public static class MappingExtensions
    {
        // UPDATE PRODUCT
        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.ID = productViewModel.ID;
            product.Name = productViewModel.Name;
            product.Alias = productViewModel.Alias;
            product.CategoryID = productViewModel.CategoryID;
            product.Image = productViewModel.Image;
            product.MoreImage = productViewModel.MoreImage;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.Description = productViewModel.Description;
            product.Content = productViewModel.Content;
            // Follow Interface
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.ViewCount = productViewModel.ViewCount;
            product.Createdate = productViewModel.Createdate;
            product.CreareBy = productViewModel.CreareBy;
            product.Status = productViewModel.Status;
            product.MetakeyWord = productViewModel.MetakeyWord;
            product.MetaDescription = productViewModel.MetaDescription;
            product.Tags = productViewModel.Tags;
            product.Quantity = productViewModel.Quantity;
        }

        // UPDATE PRODUCT CATEGORY
        public static void UpdateProductCategory(this ProductCategorye productCategorie, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategorie.ID = productCategoryViewModel.ID;
            productCategorie.Name = productCategoryViewModel.Name;
            productCategorie.Alias = productCategoryViewModel.Alias;
            productCategorie.Description = productCategoryViewModel.Description;
            productCategorie.ParentID = productCategoryViewModel.ParentID;
            productCategorie.Image = productCategoryViewModel.Image;
            productCategorie.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategorie.HomeFlag = productCategoryViewModel.HomeFlag;
            // Follow Interface
            productCategorie.Createdate = productCategoryViewModel.Createdate;
            productCategorie.CreareBy = productCategoryViewModel.CreareBy;
            productCategorie.UpdateBy = productCategoryViewModel.UpdateBy;
            productCategorie.MetakeyWord = productCategoryViewModel.MetakeyWord;
            productCategorie.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategorie.Status = productCategoryViewModel.Status;
        }

        // UPDATE PRODUCT TAG
        public static void UpdateProductTag(this ProductTag productTag, ProductTagViewModel productTagViewModel)
        {
            productTag.ProductID = productTagViewModel.ProductID;
            productTag.TagID = productTagViewModel.TagID;
        }

        // UPDATE OEDER
        public static void UpdateOrder(this Order order, OrderViewModel orderViewModel)
        {
            order.ID = orderViewModel.ID;
            order.CustomerName = orderViewModel.CustomerName;
            order.CustomerAddress = orderViewModel.CustomerAddress;
            order.CustomerPhoneNumber = orderViewModel.CustomerPhoneNumber;
            order.CustomerEmail = orderViewModel.CustomerEmail;
            order.CustomerMessage = orderViewModel.CustomerMessage;
            order.CreateDate = orderViewModel.CreateDate;
            order.CreateBy = orderViewModel.CreateBy;
            order.PaymentMethod = orderViewModel.PaymentMethod;
            order.PaymentStatuss = orderViewModel.PaymentStatuss;
            order.Statuss = orderViewModel.Statuss;
        }

        // UPDATE ORDER DETAILS
        public static void UpdateOrderDetails(this OrderDetails orderDetails, OrderDetailsViewModel orderDetailsViewModel)
        {
            orderDetails.OrderID = orderDetailsViewModel.OrderID;
            orderDetails.ProductID = orderDetailsViewModel.ProductID;
            orderDetails.Quantity = orderDetailsViewModel.Quantity;
        }

        // UPDATE CONTACT
        public static void UpdateContact(this Contact contact, ContactViewModel contactViewModel)
        {
            contact.ID = contactViewModel.ID;
            contact.Name = contactViewModel.Name;
            contact.Email = contactViewModel.Email;
            contact.PhoneNumber = contactViewModel.PhoneNumber;
            contact.Message = contactViewModel.Message;
            contact.CreateDate = contactViewModel.CreateDate;
            contact.ConfirmDate = contactViewModel.ConfirmDate;
            contact.Status = contactViewModel.Status;
        }

        //UPDATE APPLICATIONUSER

        public static void UpdateApplicationUser(this ApplicationUser applicationUser, ApplicationUserViewModel applicationUserViewModel)
        {
            applicationUser.Id = applicationUserViewModel.Id;
            applicationUser.FullName = applicationUserViewModel.FullName;
            applicationUser.Address = applicationUserViewModel.Address;
            applicationUser.BirthDay = applicationUserViewModel.BirthDay;
            applicationUser.Email = applicationUserViewModel.Email;
            applicationUser.EmailConfirmed = applicationUserViewModel.EmailConfirmed;
            applicationUser.PasswordHash = applicationUserViewModel.PasswordHash;
            applicationUser.SecurityStamp = applicationUserViewModel.SecurityStamp;
            applicationUser.PhoneNumber = applicationUserViewModel.PhoneNumber;
            applicationUser.PhoneNumberConfirmed = applicationUserViewModel.PhoneNumberConfirmed;
            applicationUser.TwoFactorEnabled = applicationUserViewModel.TwoFactorEnabled;
            applicationUser.LockoutEndDateUtc = applicationUserViewModel.LockoutEndDateUtc;
            applicationUser.LockoutEnabled = applicationUserViewModel.LockoutEnabled;
            applicationUser.AccessFailedCount = applicationUserViewModel.AccessFailedCount;
            applicationUser.UserName = applicationUserViewModel.UserName;
        }
    }
}