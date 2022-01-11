using System;

namespace SCMApp.Models
{
    public class Inventory: BusinessObjectBase
    {
        public Item item { get; set; }
        public DateTime? addedDate { get; set; }
        public int availableQuantity { get; set; }
        public string remark { get; set; }
    }
}
