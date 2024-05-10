using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Models
{
    [Table("ProductTags")]
    public class ProductTag
    {
        [Key]
        [Column(Order = 1)]
        public int ProductID { get; set; }

        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar", Order = 2)]
        public string TagID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }

        [ForeignKey("TagID")]
        public virtual Tag Tags { get; set; }
    }
}