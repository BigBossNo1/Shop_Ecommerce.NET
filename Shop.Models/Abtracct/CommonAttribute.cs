using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Abtracct
{
    public abstract class CommonAttribute : ICommonAttribute
    {
        public DateTime? Createdate { get; set; }

        [MaxLength(256)]
        public string CreareBy { get; set; }

        [MaxLength(256)]
        public string UpdateBy { get; set; }

        [Required]
        public bool Status { get; set; }

        [MaxLength(256)]
        public string MetakeyWord { get; set; }

        [MaxLength(256)]
        public string MetaDescription { get; set; }
    }
}