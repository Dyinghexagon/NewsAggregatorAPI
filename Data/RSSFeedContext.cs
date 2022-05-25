
namespace NewsAggregatorAPI.Data
{
    public class RSSFeedContext : DbContext
    {
        public RSSFeedContext(DbContextOptions<RSSFeedContext> options) : base(options)
        { }
        public DbSet<RSSChannel> RSSChannels { get; set; }
        public DbSet<RSSItem> RSSItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RSSItem>()
                .HasOne(rssChannel => rssChannel.RSSChannel)
                .WithMany(rssItem => rssItem.Items)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
