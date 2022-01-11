
namespace SCMApp.Constants
{
    public static class RouteConstants
    {
        public const string UserApi = "api/users";
        public const string LoginApiGetToken = "login";
        public const string GetAllUser = "getAllUser";
        public const string CreateUser = "register";

        //Item 
        public const string ItemApi = "api/items";
        public const string GetItemByItemNumber = "getItems/{0}";
        public const string SearchItem = "?searchValue={0}";
        public const string CreateNewItem = "";

        //ItemType
        public const string ItemTypeApi = "api/itemType";
        public const string GetAllItemType = "getActiveItemType";
        public const string GetNewestIdOfItemtype = "getNewId";
        public const string CreateNewItemtype = "";

        //Partner
        public const string PartnerApi = "api/supplier";
        public const string GetAllPartner = "getAllSupplier";
        public const string CreateParter = "";

        //Customer
        public const string CustomerApi = "api/customer";
        public const string GetAllCustomer = "getAllCustomer";
        public const string CreateCustomer = "";

        // Invoice
        public const string InvoiceApi = "api/invoices";
        public const string GetAllInvoice = "getAllInvoice";
        public const string CreateInvoice = "createFull";

        //Inventory
        public const string InventoryApi = "api/inventoryCheck";
        public const string GetAllInventoryTicket = "getAllInventoryCheck";
        public const string CreateInventoryTicket = "";

    }
}
