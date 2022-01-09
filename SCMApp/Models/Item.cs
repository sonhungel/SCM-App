using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Item : BusinessObjectBase
    {
        public int itemNumber { get; set; }
        public string name { get; set; }
        public ItemType itemType { get; set; }
        public int cost { get; set; }
        public int quantity { get; set; }
        public int salesPrice { get; set; }
        public int minimumQuantity { get; set; }
        public int availableQuantity { get; set; }
        public string remark { get; set; }
        public string description { get; set; }
        public Partner supplier { get; set; }
    }
}
