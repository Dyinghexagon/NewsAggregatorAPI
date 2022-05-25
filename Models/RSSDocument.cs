using System.ComponentModel.DataAnnotations;

namespace NewsAggregatorAPI.Models
{
    public abstract class RSSDocument
    {
        [Required]
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Link { get; set; }
        public String Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Object type: " + this.GetType().Name);
            sb.AppendLine("Title: " + this.Title);
            sb.AppendLine("Link: " + this.Link);
            sb.AppendLine("Description: " + this.Description);
            return sb.ToString();
        }
    }
}
