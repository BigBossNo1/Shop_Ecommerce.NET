using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu ")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}