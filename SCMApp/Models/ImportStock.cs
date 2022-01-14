using System;

namespace SCMApp.Models
{
    public class ImportStock: BusinessObjectBase
    {
        public DateTime addedDate { get; set; }
        public Partner supplier { get; set; }
        public Item item { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public string remark { get; set; }
    }
}
