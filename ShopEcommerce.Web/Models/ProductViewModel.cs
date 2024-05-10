using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Web.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string Image { get; set; }

        public string MoreImage { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime? Createdate { get; set; }

        public string CreareBy { get; set; }

        public string UpdateBy { get; set; }

        [Required]
        public bool Status { get; set; }

        public string MetakeyWord { get; set; }

        public string MetaDescription { get; set; }
        public virtual ProductCategoryViewModel ProductCategoryes { get; set; }
        public virtual IEnumerable<ProductTagViewModel> ProductTag { get; set; }
    }
}