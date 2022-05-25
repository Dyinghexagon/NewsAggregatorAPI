namespace NewsAggregatorAPI.Models
{
    public class RSSItem : RSSDocument
    {
        public Int32? RSSChannelId { get; set; }
        public RSSChannel RSSChannel { get; set; }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Title RSSItem: " + this.Title);
            sb.AppendLine("Link RSSItem: " + this.Link);
            sb.AppendLine("Description RSSItem: " + this.Description);
            return sb.ToString();
        }
    }
}
