using System;

namespace Shop.Models.Abtracct
{
    public interface ICommonAttribute
    {
        DateTime? Createdate { get; set; }
        string CreareBy { get; set; }
        string UpdateBy { get; set; }
        bool Status { get; set; }
        string MetakeyWord { get; set; }
        string MetaDescription { get; set; }
    }
}