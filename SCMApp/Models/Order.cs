using System;

namespace SCMApp.Models
{
    public class Order: BusinessObjectBase
    {
        public DateTime addedDate { get; set; }
        public Customer customer { get; set; }
        public int paid { get; set; }
        public UserProfile user { get; set; }
    }
}
