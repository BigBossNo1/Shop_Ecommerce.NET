using Shop.Models.Abtracct;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Models
{
    [Table("ProductCategoryes")]
    public class ProductCategorye : CommonAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }

        [MaxLength(256)]
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}