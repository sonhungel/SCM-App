using SCMApp.Helper;
using SCMApp.Models;

namespace SCMApp.Presentation.ViewModels.ItemsViewModel
{
    public class InventoryViewModelItem
    {
        public InventoryViewModelItem(Inventory inventory)
        {
            Model = inventory;
        }
        public Inventory Model { get; set; }
        public int InventoryTicketCode => Model.id;
        public string DateOfCreate => DateTimeHelper.DateTimeToStandardString(Model.addedDate);
        public int StockCode => Model.item.itemNumber;
        public string StockName => Model.item.name;
        public int InventoryNumber => Model.item.quantity;
        public int InventoryNumberFact => Model.availableQuantity;
        public int QuantityOfDifference
        {
            get
            {
                var valueOfDifference = Model.item.quantity - Model.availableQuantity;
                return valueOfDifference < 0 ? valueOfDifference * -1 : valueOfDifference;
            }
        }
        public string Note => Model.remark;
    }
}
