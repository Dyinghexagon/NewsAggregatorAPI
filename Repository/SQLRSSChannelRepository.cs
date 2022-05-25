namespace NewsAggregatorAPI.Repository
{
    public class SQLRSSChannelRepository : IRepository
    {
        private readonly RSSFeedContext _repository;
        private bool disposed = false;

        public SQLRSSChannelRepository(RSSFeedContext repository) 
        {
            _repository = repository;
        }
        public IEnumerable<RSSChannel> GetRSSChannels() 
        {
            var rssChannels = _repository.RSSChannels.ToArray();
            if(rssChannels == null) 
            {
                throw new Exception("Not found RSS-Channels.");
            }
            return rssChannels;
        }
        public RSSChannel GetRSSChannel(Int32 id) 
        {
            var rssChannel = _repository.RSSChannels.Find(id);
            if(rssChannel == null) 
            {
                throw new Exception("Not found RSS-Channels.");
            }
            return rssChannel;
        }
        public IEnumerable<RSSItem> GetRSSItems() 
        {
            return _repository.RSSItems.ToArray();
        }
        public IEnumerable<RSSItem> GetRSSItemsFindSubTitle(String subTitle)
        {
            var rssItems = 
                from rssItem in _repository.RSSItems
                where rssItem.Title.Contains(subTitle)
                select rssItem;
            return rssItems;               
            throw new NotImplementedException();
        }
        public void Create(String link) 
        {
            var rssChannel = RSSChannelInitializer.GetRSSChannelInitialized(link);
            if(rssChannel == null) 
            {
                throw new Exception("Erorr RSS-Link.");
            }
            _repository.RSSChannels.Add(rssChannel);
            _repository.SaveChanges();
        }
        public void Update(Int32 id, String link) 
        {
            var rssChannel = _repository.RSSChannels.Find(id);
            if( rssChannel == null) 
            {
                throw new Exception("Not found RSS-Channels.");
            }
            var editableRSSChannel = RSSChannelInitializer.GetRSSChannelInitialized(link);
            if(editableRSSChannel == null) 
            {
                throw new Exception("Erorr RSS-Link.");
            }
            _repository.RSSChannels.Remove(rssChannel);
            _repository.RSSChannels.Add(editableRSSChannel);
            foreach (RSSItem rssItem in editableRSSChannel.Items)
            {
                _repository.RSSItems.Add(rssItem);
            }
            _repository.SaveChanges();
        }
        public void Delete(Int32 id) 
        {
            var rssChannel = _repository.RSSChannels.Find(id);
            if (rssChannel == null)
            {
                throw new Exception("Erorr RSS-Link.");
            }
            _repository.RSSChannels.Remove(rssChannel);
            _repository.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
