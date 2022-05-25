namespace NewsAggregatorAPI.Models
{
    public class RSSChannelInitializer
    {
        public static RSSChannel GetRSSChannelInitialized(String link)
        {

            XmlTextReader xmlTextReader = new XmlTextReader(link);
            XmlDocument xmlDocument = new XmlDocument();
            RSSChannel channel = new RSSChannel();
            try
            {
                xmlDocument.Load(xmlTextReader);
                xmlTextReader.Close();
                XmlNode channelXmlNode = xmlDocument.GetElementsByTagName("channel")[0];
                if (channelXmlNode != null)
                {
                    foreach (XmlNode node in channelXmlNode.ChildNodes)
                    {
                        if (node.Name == "item")
                        {
                            RSSItem rssItem = new RSSItem();
                            foreach (XmlNode nodeItem in node.ChildNodes)
                            {
                                DefinitionNode(nodeItem, rssItem);
                            }
                            channel.Items.Add(rssItem);
                        }
                        else
                        {
                            DefinitionNode(node, channel);
                        }
                    }
                }
                else
                {
                    throw new Exception("Rss-channel not found!");
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == System.Net.WebExceptionStatus.NameResolutionFailure)
                    throw new Exception("Unable to connect to the specified source." + link);
                else throw ex;
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("File " + link + " not found!");
            }
            catch (HttpRequestException)
            {
                throw new Exception("Error code: 404 " + link + " not found!");
            }
            return channel;
        }

        private static void DefinitionNode(XmlNode node, RSSDocument document)
        {
            switch (node.Name)
            {
                case "title":
                    {
                        document.Title = node.InnerText;
                        break;
                    }
                case "description":
                    {
                        document.Description = node.OwnerDocument.InnerText;
                        break;
                    }
                case "link":
                    {
                        document.Link = node.InnerText;
                        break;
                    }
            }
        }

    }
}
