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
            typeName = name;
        }
        public string typeName { get;set;}
        public string remark { get;set;}
    }
}
