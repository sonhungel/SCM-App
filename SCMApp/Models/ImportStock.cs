using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class ImportStock
    {
        public string ImportStockCode => "12345123";
        public string StockName => "Bánh kem";

        public DateTime ImportStockTime => DateTime.Now;
        public string Supplier => "Shopee";
        public int Cost => 400000;

    }
}
