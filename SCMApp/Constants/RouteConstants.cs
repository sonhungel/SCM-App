﻿using System;
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
        public const string GetAllUser = "getAllUser";
        public const string GetUserProfileBaseOnToken = "admin";

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

        //Customer
        public const string CustomerApi = "api/customer";
        public const string GetAllCustomer = "getAllCustomer";

        // Invoice
        public const string InvoiceApi = "api/invoices";
        public const string GetAllInvoice = "getAllInvoice";

        //Inventory
        public const string InventoryApi = "api/inventoryCheck";
        public const string GetAllInventoryTicket = "getAllInventoryCheck";
        public const string CreateInventoryTicket = "inventoryCheck";
    }
}
