using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Item : BusinessObjectBase
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public string ItemType { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public int RetailPrice { get; set; }
        public int MinimumQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public string Supplier { get; set; }
    }
}
