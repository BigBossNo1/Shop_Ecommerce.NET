using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }
        public DateTime? Createdate { get; set; }

        public string CreareBy { get; set; }

        public string UpdateBy { get; set; }

        [Required]
        public bool Status { get; set; }

        public string MetakeyWord { get; set; }

        public string MetaDescription { get; set; }
        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}