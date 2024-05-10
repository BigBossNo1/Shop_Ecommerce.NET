using System;
using System.Collections.Generic;

namespace ShopEcommerce.Web.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerMessage { get; set; }

        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatuss { get; set; }
        public bool Statuss { get; set; }
        public virtual IEnumerable<OrderDetailsViewModel> OrderDetails { get; set; }
    }
}