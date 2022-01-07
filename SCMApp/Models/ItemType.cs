using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Models
{
    public class ItemType : BusinessObjectBase
    {
        public ItemType(int id,string name)
        {
            this.id = id;
            itemTypeName = name;
        }
        public string itemTypeName {get;set;}
        public string note {get;set;}
    }
}
