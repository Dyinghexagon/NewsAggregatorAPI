namespace NewsAggregatorAPI.Models
{
    public class RSSChannel : RSSDocument
    {
        public IList<RSSItem> Items { get; } = new List<RSSItem>();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Title: " + this.Title);
            sb.AppendLine("Link: " + this.Link);
            sb.AppendLine("Description: " + this.Description);
            return sb.ToString();
        }
    }
}
