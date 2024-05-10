using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Models
{
    [Table("OderDetails")]
    public class OrderDetails
    {
        [Key]
        [Column(Order = 1)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        // Foreingkey order
        [ForeignKey("OrderID")]
        public virtual Order Oders { get; set; }

        // Foreingkey product
        [ForeignKey("ProductID")]
        public virtual Product Products { get; set; }
    }
}