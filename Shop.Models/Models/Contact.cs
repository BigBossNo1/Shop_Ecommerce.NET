using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(256)]
        [Required]
        public string Name { get; set; }

        [StringLength(256)]
        [Required]
        public string Email { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [StringLength(256)]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}