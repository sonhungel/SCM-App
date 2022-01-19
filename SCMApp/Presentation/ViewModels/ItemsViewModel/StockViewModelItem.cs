using SCMApp.Constants;
using SCMApp.Helper;
using SCMApp.Models;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class StockViewModelItem
    {
        public StockViewModelItem(Item item)
        {
            Model = item;
        }
        public Item Model;

        public string StockName => Model.name;
        public int StockCode => Model.itemNumber;

        public string StockOriginPrice => MoneyHelper.IntToStandardMoneyStringWithTail(Model.cost);
        public string StockRetailPrice => MoneyHelper.IntToStandardMoneyStringWithTail(Model.salesPrice);

        public int Quantity => Model.availableQuantity;
        public string Remark => Model.remark;
        public string ColorRow
        {
            get
            {
                if (Model.availableQuantity <= Model.minimumQuantity)
                {
                    TooltipText = "Số lượng hiện có đang ít hơn số lượng tối thiểu!";
                    return CommonConstants.RED;
                }
                else if (Model.supplier.internalState == "DELETED")
                {
                    TooltipText = "Nhà cung cấp hiện đã bị xoá khỏi hệ thống!";
                    return CommonConstants.YELLOW;
                }
                else if (Model.availableQuantity > Model.minimumQuantity *10)
                {
                    TooltipText = "Số lượng hiện có đang nhiều, ưu tiên bán!";
                    return CommonConstants.BlUE;
                }
                return "4";
            }
        }

        public string TooltipText { get; set; }
    }
}
