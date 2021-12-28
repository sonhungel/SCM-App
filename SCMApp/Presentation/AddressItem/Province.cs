using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.AddressItem
{
    public class Province : AddressBase
    {
        public Province()
        {
            Districts = new List<District>();
        }
        public IList<District> Districts { get; set; }
    }
}
