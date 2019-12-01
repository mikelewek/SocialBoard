using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialWebApi.Models;

namespace SocialWebApi.Controllers
{
    /// <summary>
    /// Get data from external social media endpoints including Twitter and Instagram
    /// </summary>  
    [ApiController]
    [Route("api/[controller]")]
    public class SocialController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SocialController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("instatweets/term/{term}")]
        public ActionResult GetTweetAndInstaByTerm(string term)
        {
            TwitterQuery tw = new TwitterQuery(_config);
            var query = tw.GetTweetsByTerm(term);

            return Ok(query);
        }

        [HttpGet("tweets/term/{term}")]
        public ActionResult GetTweetByTerm(string term)
        {
            TwitterQuery tw = new TwitterQuery(_config);
            var query = tw.GetTweetsByTerm(term);

            return Ok(query);
        }

        [HttpGet("tweets/id/{id}")]
        public ActionResult<SocialBoardTweetsDto> GetTweetById(string id)
        {
            TwitterQuery tw = new TwitterQuery(_config);
            var query = tw.GetTweet(Convert.ToUInt64(id));

            if(query == null)
            {
                return NotFound();
            }

			return Ok(query);
        }

        [HttpGet("tweets/screenname/{screename}")]
        public ActionResult<string> GetUserTweets(string screename)
        {
            TwitterQuery tw = new TwitterQuery(_config);
			IEnumerable<SocialBoardTweets> query = tw.GetTweetsByUsername(screename);
            return Ok(query);
        }

        [HttpGet("instas/{term}")]
        public async Task<IActionResult> GetInstaByTerm(string term)
        {
            InstaQuery insta = new InstaQuery();
            await insta.Auth();
            var query = await insta.GetInstaByTag(term);
            return Ok(query);
        }

        [HttpGet("instas/id/{mediaId}")]
        public async Task<IActionResult> GetInstaById(string mediaId)
        {
            InstaQuery insta = new InstaQuery();
            await insta.Auth();
            var query = await insta.GetInstaById(mediaId);
            return Ok(query);
        }

        [HttpGet("instas/screenname/{screename}")]
        public async Task<IActionResult> GetUserInstas(string screename)
        {
            InstaQuery insta = new InstaQuery();
            await insta.Auth();
            var query = await insta.GetInstaByUsername(screename);
            return Ok(query);
        }
    }
}
