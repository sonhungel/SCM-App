using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SCMApp.Presentation.AddressItem
{
    public class Address
    {
        private static Address _instance;

        public Address()
        {
            using (StreamReader r = new StreamReader("../../../Assets/DataAddress.json"))
            {
                string json = r.ReadToEnd();
                ProvinceList = JsonConvert.DeserializeObject<List<Province>>(json);
            }
        }

        public static Address Instance()
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new Address();
            }
            return _instance;
        }

        public readonly IList<Province> ProvinceList;
    }
}

