using SCMApp.Models;
using SCMApp.WebAPIClient.Request_Response; 
using System.Collections.Generic; 

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IItemWebAPI
    {
        IList<Item> GetAllItem(string token);
        Item GetItemByItemNumber(string numberRequest, string token);
        bool CreateItem(CreateItemDTO createItemDTO, string token);
        string UpdateItem( string token);
        string DeleteItem();
    }
}
