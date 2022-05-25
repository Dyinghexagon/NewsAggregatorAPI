using Microsoft.AspNetCore.Mvc;
using NewsAggregatorAPI.Repository;
using System.Text.Unicode;
using System.Text.Json;
using System.Text.Encodings.Web;
namespace NewsAggregatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSSFeedController : Controller
    {
        IRepository _repository;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        public RSSFeedController(RSSFeedContext repository) 
        {
            _repository = new SQLRSSChannelRepository(repository);
        }
        [HttpGet]
        public IActionResult GetRSSChannels()
        {
            var rssChannels = _repository.GetRSSChannels().ToList();
            try
            {
                String jsonString = JsonSerializer.Serialize(rssChannels, options);
                return Ok(jsonString);
            }
            catch 
            {
                return BadRequest();
            }
        }
        [HttpGet("RSSItems")]
        public IActionResult GetRSSItems() 
        {
            var rssItems = _repository.GetRSSItems().ToList();
            try
            {
                String jsonString = JsonSerializer.Serialize(rssItems, options);
                return Ok(jsonString);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("RSSItems/Find")]
        public IActionResult GetRSSItem(String subStringTitle)
        {
            var rssItems = _repository.GetRSSItemsFindSubTitle(subStringTitle).ToList();
            try
            {
                String jsonString = JsonSerializer.Serialize(rssItems, options);
                return Ok(jsonString);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("id")]
        public IActionResult GetRSSChannel(Int32 id)
        {
            var rssChannel = _repository.GetRSSChannel(id);

            try
            {
                String jsonString = JsonSerializer.Serialize(rssChannel, options);
                return Ok(jsonString);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("Link")]
        public ActionResult CreateRSSChanel(String link)
        {
            _repository.Create(link);
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult UpdeteRSSChannel(Int32 id, String linkEditableRssChannel)
        {
            _repository.Update(id, linkEditableRssChannel);
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public ActionResult DeleteRSSChannel(Int32 id)
        {
            _repository.Delete(id);
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
