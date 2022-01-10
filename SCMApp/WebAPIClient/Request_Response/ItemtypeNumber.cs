using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCMApp.WebAPIClient.Request_Response
{
    public class ItemtypeNumber
    {
        public ItemtypeNumber(int _id)
        {
            id = _id;
        }
        public int id { get; set; }
    }
}
