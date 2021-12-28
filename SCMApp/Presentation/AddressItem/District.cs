using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.AddressItem
{
    public class District : AddressBase
    {
        public District()
        {
            Wards = new List<Ward>();
        }
        public IList<Ward> Wards { get; set; }

    }
}
