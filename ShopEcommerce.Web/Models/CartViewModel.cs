using System;

namespace ShopEcommerce.Web.Models
{
    [Serializable]
    public class CartViewModel
    {
        public int ProductID { get; set; }
        public ProductViewModel Product { get; set; }
        public int Quantity { get; set; }
    }
}