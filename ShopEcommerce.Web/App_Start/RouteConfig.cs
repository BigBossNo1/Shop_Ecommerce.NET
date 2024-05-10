using System.Web.Mvc;
using System.Web.Routing;

namespace ShopEcommerce.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });


            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Page Home",
                url: "home",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Page Login",
                url: "login-infor",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Page Register",
                url: "register-infor",
                defaults: new { controller = "Account", action = "Register", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Page Cart Detal",
                url: "cart-infor",
                defaults: new { controller = "Cart", action = "CartDetail", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Page Cart Add",
                url: "add-cart",
                defaults: new { controller = "Cart", action = "Add", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Page Payment",
                url: "payment",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Order success",
                url: "order-success",
                defaults: new { controller = "Cart", action = "OrderSuccess", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Product Category",
                url: "{alias}-pc-{id}/infor",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product ",
                url: "{alias}-p-{id}/infor",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Product By Tag ",
                url: "{tagID}/infor",
                defaults: new { controller = "Product", action = "ProductTag", tagID = UrlParameter.Optional },
                namespaces: new string[] { "ShopEcommerce.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}