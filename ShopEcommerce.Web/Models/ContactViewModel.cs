using System;
using System.ComponentModel.DataAnnotations;

namespace ShopEcommerce.Web.Models
{
    public class ContactViewModel
    {
        public int ID { get; set; }

        [MaxLength(256 , ErrorMessage ="Họ tên không quá 256 ký tự!")]
        [Required(ErrorMessage ="Bắt buộc phải nhập tên ")]
        public string Name { get; set; }

        [MaxLength(256, ErrorMessage = "Email  không quá 256 ký tự!")]
        [Required(ErrorMessage = "Bắt buộc phải nhập email ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải số điện thoại ")]
        public int PhoneNumber { get; set; }

        [MaxLength(500, ErrorMessage = "Lời nhắn không quá 256 ký tự!")]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? ConfirmDate { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập trạng thái ")]
        public bool Status { get; set; }
    }
}