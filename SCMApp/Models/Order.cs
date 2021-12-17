using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Order
    {
        public string OrderCode { get; set; }
        public DateTime OrderTime { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal CustomerPaid { get; set; }
    }
}
