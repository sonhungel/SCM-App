
namespace SCMApp.Constants
{
    public static class RouteConstants
    {
        public const string UserApi = "api/users";
        public const string LoginApiGetToken = "login";
        public const string GetAllUser = "getAllUser";
        public const string CreateUser = "register";
        public const string UpdateUser = "update";
        public const string UpdateByManager = "update/admin";
        public const string DeleteUser = "delete/{0}";

        //Item 
        public const string ItemApi = "api/items";
        public const string GetItemByItemNumber = "getItems/{0}";
        public const string SearchItem = "?searchValue={0}";
        public const string CreateNewItem = "";
        public const string UpdateItem = "";
        public const string DeleteItem = "delete/{0}";

        //ItemType
        public const string ItemTypeApi = "api/itemType";
        public const string GetAllItemType = "getActiveItemType";
        public const string GetNewestIdOfItemtype = "getNewId";
        public const string CreateNewItemtype = "";

        //Partner
        public const string PartnerApi = "api/supplier";
        public const string GetAllPartner = "getAllSupplier";
        public const string CreateParter = "";
        public const string UpdatePartner = "";
        public const string DeleteSupplier = "delete/{0}";

        //Customer
        public const string CustomerApi = "api/customer";
        public const string GetAllCustomer = "getAllCustomer";
        public const string CreateCustomer = "";
        public const string UpdateCustomer = "";
        public const string DeleteCustomer = "delete/{0}";

        // Invoice
        public const string InvoiceApi = "api/invoices";
        public const string GetAllInvoice = "getAllInvoice/{0}";
        public const string CreateInvoice = "createFull";

        //Inventory
        public const string InventoryApi = "api/inventoryCheck";
        public const string GetAllInventoryTicket = "getAllInventoryCheck";
        public const string CreateInventoryTicket = "";

        // import stock
        public const string ImportStockApi = "api/supTicket";

        //profit
        public const string ProfitApi = "api/report";
        public const string AllReport = "dailyReport";
        public const string MonthlyReport = "monthlyReport";
    }
}
