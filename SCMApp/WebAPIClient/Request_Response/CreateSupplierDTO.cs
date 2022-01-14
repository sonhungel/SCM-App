 

namespace SCMApp.WebAPIClient.Request_Response
{
    public class CreateSupplierDTO
    {
        public int? supplierNumber { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public int province { get; set; }
        public int district { get; set; }
        public int ward { get; set; }
        public string address { get; set; }
        public int type { get; set; }
        public string taxNumber { get; set; }
        public string remark { get; set; }
    }
}
