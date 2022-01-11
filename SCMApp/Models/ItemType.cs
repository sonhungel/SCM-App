
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
        public string description { get;set;}
    }
}
