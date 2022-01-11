using SCMApp.Models; 
using System.Collections.Generic; 

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IItemTypeWebAPI
    {
        IList<ItemType> GetAllItemType(string token);
        ItemType GetItemNewestId(string token);
        bool CreateItemtype(ItemType itemType, string token);
    }
}
