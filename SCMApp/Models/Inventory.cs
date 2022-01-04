using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Inventory
    {
        public string InvetoryTicketCode { get; set; }
        public Item Item { get; set; }
        public int StockInventoryQuantity { get; set; }
        public int FactQuantity { get; set; }
        public int AmountOfDifference { get; set; }
        public string Note { get; set; }
    }
}
