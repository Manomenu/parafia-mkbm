namespace parafia_mbkm.Models
{
    //change to ArticleModel
    public class ArticleView
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public ArticleView()
        {
            Header = "";
            Content = "";
        }
    }
}
