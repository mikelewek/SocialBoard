using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InstaSharper.Classes.Models;
using LinqToTwitter;
using Microsoft.AspNetCore.Mvc;
using SocialWebApi.Models;
using SocialWebApi.Repositories;

namespace SocialWebApi.Controllers
{
    /// <summary>
    /// Get data from external social media endpoints including Twitter and Instagram
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;

        public SocialController(IMapper mapper)
        {
            _uow = new UnitOfWork();
            _mapper = mapper;
		}

        [HttpGet("instatweets/term/{term}")]
        public ActionResult<string> GetTweetAndInstaByTerm(string term)
        {
            TwitterQuery tw = new TwitterQuery();
            var query = tw.GetTweetsByTerm(term);

            // combine
            //InstaQuery insta = new InstaQuery();
            //await insta.Auth();
            //var json = await insta.GetInstaByTag(term);

            return Ok(query);
        }

        [HttpGet("tweets/term/{term}")]
        public ActionResult<string> GetTweetByTerm(string term)
        {
            TwitterQuery tw = new TwitterQuery();
            var query = tw.GetTweetsByTerm(term);

            return Ok(query);
        }

        [HttpGet("tweets/id/{id}")]
		public ActionResult<SocialBoardTweetsDto> GetTweetById(string id)
        {
            TwitterQuery tw = new TwitterQuery();
            var tweet = tw.GetTweet(Convert.ToUInt64(id));
            List<SocialBoardTweetsDto> query = _mapper.Map<List<SocialBoardTweetsDto>>(tweet);

            if(query == null)
            {
                return NotFound();
            }

			return Ok(query);
        }

        [HttpGet("tweets/screenname/{screename}")]
		public ActionResult<string> GetUserTweets(string screename)
        {
            TwitterQuery tw = new TwitterQuery();
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
