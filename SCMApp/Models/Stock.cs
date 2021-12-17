using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class Stock
    {
        public string StockName => "Bánh chuối";
        public string StockType => "bánh";
        public string StockCode => "12341";

        public int StockOriginPrice => 345555;
        public int StockRetailPrice => 400000;

        public string Supplier => "Shopee";
    }
}
