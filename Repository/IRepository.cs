namespace NewsAggregatorAPI.Repository
{
    public interface IRepository : IDisposable
    {
        public IEnumerable<RSSChannel> GetRSSChannels();
        public RSSChannel GetRSSChannel(Int32 id);
        public IEnumerable<RSSItem> GetRSSItems();
        public IEnumerable<RSSItem> GetRSSItemsFindSubTitle(String subTitle);
        public void Create(String link);
        public void Update(Int32 id,String link);
        public void Delete(Int32 id);
    }
}
