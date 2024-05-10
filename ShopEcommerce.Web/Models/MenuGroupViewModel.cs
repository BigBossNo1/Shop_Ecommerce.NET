using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopEcommerce.Web.Models
{
    public class MenuGroupViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<MenuViewModel> Menus { get; set; }
    }
}