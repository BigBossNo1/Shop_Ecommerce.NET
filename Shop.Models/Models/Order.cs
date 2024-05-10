using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerPhoneNumber { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { get; set; }

        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatuss { get; set; }
        public bool Statuss { get; set; }
        public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }
        //
    }
}