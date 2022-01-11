 

namespace SCMApp.WebAPIClient.Request_Response
{
    public class CreateInventoryDTO
    {
        public ItemNumber item { get; set; }
        public int availableQuantity { get; set; }
        public string remark { get; set; }
    }
}
