using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.AddressItem
{
    public class AddressBase
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string GetName() { return Name; }
    }
}
