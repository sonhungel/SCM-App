using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Constants
{
    public static class RouteConstants
    {
        /// <summary>
        /// Route Constants for Loggin
        /// </summary>

        public const string LoginApi = "api/users";
        public const string LoginApiGetToken = "login";

        public const string UserRoleApi = "api/role";
        public const string GetUserProfile = "getUserPermission";

        //Item 
        public const string ItemApi = "api/items";
        public const string GetItemByItemNumber = "getItems";

        //ItemType
        public const string ItemTypeApi = "api/itemType";

        //HRM
        public const string HRMApi = "api/HRM";

        //Partner
        public const string PartnerApi = "api/supplier";

        //Customer
        public const string CustomerApi = "api/customer";

        // Invoice
        public const string InvoiceApi = "api/invoices";
    }
}
