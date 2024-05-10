using System.Collections.Generic;

namespace ShopEcommerce.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ProductViewModel> lastesProduct { get; set; }
        public IEnumerable<ProductCategoryViewModel> latesProductCategory { get; set; }
    }
}