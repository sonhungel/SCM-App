
using System;

namespace SCMApp.Models
{
    public class Partner: BusinessObjectBase
    {
        public int? supplierNumber { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public int province { get; set; }
        public int district { get; set; }
        public int ward { get; set; }
        public string address { get; set; }
        public bool type { get; set; }
        public string taxNumber { get; set; }
        public string remark { get; set; }
        public int paid { get; set; }
        public DateTime? LastTimeBuy { get; set; }
    }
}
