
namespace SCMApp.WebAPIClient.Request_Response
{
    public class CreateInvoiceDetailDTO
    {
        public int itemNumber { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int discount { get; set; }
    }
}
