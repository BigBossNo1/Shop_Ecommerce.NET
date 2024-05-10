namespace ShopEcommerce.Web.Models
{
    public class MenuViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        public int GropuID { get; set; }

        public string Taget { get; set; }

        public bool Status { get; set; }
    }
}