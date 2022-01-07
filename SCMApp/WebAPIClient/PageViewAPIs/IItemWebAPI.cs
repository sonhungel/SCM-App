using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.WebAPIClient.PageViewAPIs
{
    public interface IItemWebAPI
    {
        void GetAllItem();
        void GetItemByCriteria(string criteria);
        void CreateItem();
        void UpdateItem();
        void DeleteItem();
    }
}
