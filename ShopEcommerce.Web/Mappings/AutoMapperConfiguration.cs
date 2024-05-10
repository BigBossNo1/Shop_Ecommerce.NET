using AutoMapper;
using Shop.Models.Models;
using ShopEcommerce.Web.Models;

namespace ShopEcommerce.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Footer, FooterViewModel>();
            Mapper.CreateMap<Menu, MenuViewModel>();
            Mapper.CreateMap<MenuGroup, MenuGroupViewModel>();
            Mapper.CreateMap<Order, OrderViewModel>();
            Mapper.CreateMap<OrderDetails, OrderDetailsViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductCategorye, ProductCategoryViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
            Mapper.CreateMap<Contact, ContactViewModel>();
            Mapper.CreateMap<ApplicationUser, ApplicationUserViewModel>();
        }
    }
}