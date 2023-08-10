
namespace parafia_mbkm.View;

public class ContactModel
{
    public class ContactLineModel
    {
        public string Category { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }

        public ContactLineModel() 
        {
            Category = "";
            Value = "";
            Icon = "";
        }
    }

    public string ContactTitle { get; set; }
    public List<ContactLineModel> ContactLines { get; set; }
    public ContactModel()
    {
        ContactLines = new List<ContactLineModel>();
        ContactTitle = "";
    }
}
