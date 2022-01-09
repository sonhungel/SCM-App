using SCMApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IItemTypeWebAPI
    {
        IList<ItemType> GetAllItemType(string token);
    }
}
