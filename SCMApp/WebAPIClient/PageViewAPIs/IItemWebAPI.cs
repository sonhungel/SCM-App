using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IItemWebAPI
    {
        IList<Item> GetAllItem(string token);
        Item GetItemByItemNumber(string numberRequest, string token);
        void CreateItem();
        void UpdateItem();
        void DeleteItem();
    }
}
