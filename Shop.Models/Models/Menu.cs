using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Models
{
    [Table("Menus")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string URL { get; set; }

        public int? DisplayOrder { get; set; }

        [Required]
        public int GropuID { get; set; }

        [ForeignKey("GropuID")]
        public virtual MenuGroup MenuGroups { get; set; }

        [MaxLength(50)]
        public string Taget { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}