using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialWebApi.Models;

namespace SocialWebApi.Controllers
{
    /// <summary>
    /// Get data from external Twitter and Instagram endpoints
    /// </summary>  
    [ApiController]
    [Route("api/[controller]")]
    public class SocialController : ControllerBase
    {
        private readonly TwitterQuery _tw;
    
        public SocialController()
        {
            _tw = new TwitterQuery();
        }

        //[HttpGet("instatweets/term/{term}")]
        //public ActionResult GetTweetAndInstaByTerm(string term)
        //{
        //    TwitterQuery tw = new TwitterQuery(_config);
        //    var model = new TweetViewModel()
        //    {
        //        Tweets = _mapper.Map<List<SocialBoardTweetsDto>>(tw.GetTweetsByTerm(term))
        //    };

        //    return Ok(model);
        //}

        [HttpGet("tweets/term/{term}")]
        public ActionResult GetTweetByTerm(string term)
        {
            var model = new TweetViewModel()
            {
                Tweets = _tw.GetTweetsByTerm(term)
            };

            return Ok(model);
        }

        [HttpGet("tweets/id/{id}")]
        public async Task<ActionResult<TweetsDto>> GetTweetById(string id)
        {
            var query = await _tw.GetTweet(Convert.ToUInt64(id));

            if(query == null)
            {
                return NotFound();
            }

            var model = new TweetViewModel()
            {
                Tweets = query
            };
            return Ok(model);
        }

        [HttpGet("tweets/screenname/{screename}")]
        public async Task<ActionResult<string>> GetUserTweetsAsync(string screename)
        {

            var model = new TweetViewModel()
            {
                Tweets = await _tw.GetTweetsByUsernameAsync(screename)
            };

            return Ok(model.Tweets);
        }

        //[HttpGet("instas/{term}")]
        //public async Task<IActionResult> GetInstaByTerm(string term)
        //{
        //    InstaQuery insta = new InstaQuery();
        //    await insta.Auth();
        //    var query = await insta.GetInstaByTag(term);
        //    return Ok(query);
        //}

        //[HttpGet("instas/id/{mediaId}")]
        //public async Task<IActionResult> GetInstaById(string mediaId)
        //{
        //    InstaQuery insta = new InstaQuery();
        //    await insta.Auth();
        //    var query = await insta.GetInstaById(mediaId);
        //    return Ok(query);
        //}

        //[HttpGet("instas/screenname/{screename}")]
        //public async Task<IActionResult> GetUserInstas(string screename)
        //{
        //    InstaQuery insta = new InstaQuery();
        //    await insta.Auth();
        //    var query = await insta.GetInstaByUsername(screename);
        //    return Ok(query);
        //}
    }
}
