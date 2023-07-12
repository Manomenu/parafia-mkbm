using parafia_mbkm.data.Models;

namespace parafia_mbkm.ModelViews
{
    public class ContactView
    {
        public class ContactLineView
        {
            public string Category { get; set; }
            public string Value { get; set; }
            public string Icon { get; set; }

            public ContactLineView() 
            {
                Category = "";
                Value = "";
                Icon = "";
            }
        }

        public string ContactTitle { get; set; }
        public List<ContactLineView> ContactLines { get; set; }
        public ContactView()
        {
            ContactLines = new List<ContactLineView>();
            ContactTitle = "";
        }
    }
}
