using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialWebApi.Attributes;
using SocialWebApi.Models;

namespace SocialWebApi.Controllers
{
    /// <summary>
    /// Save and get featured tweets in project database
    /// </summary>

    // api/post
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SocialContext _context;

        public PostController(IMapper mapper, SocialContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 10)]
        public IActionResult Get()
        {
            // get featured posts
            var json = _context.SocialBoardTweets;
            return Ok(json);
        }

        [HttpGet("tweets/id/{id}")]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 10)]
        public ActionResult<SocialBoardTweets> GetTweetById(string id)
        {
            TwitterQuery tw = new TwitterQuery();
            var tweet = tw.GetTweet(Convert.ToUInt64(id));
            List<SocialBoardTweetsDto> query = _mapper.Map<List<SocialBoardTweetsDto>>(tweet);

            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }

        // add post to featured post grid
        // POST api/post
        [HttpPost]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 10)]
        public IActionResult Post([FromBody] SocialBoardTweetsDto model)
        {
            if (ModelState.IsValid)
            {
                model.DateAdded = DateTime.Now;
                var tweet = _mapper.Map<SocialBoardTweets>(model);

                _context.SocialBoardTweets.Add(tweet);
                _context.SaveChanges();

                return NoContent();
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("{postId}")]
        public IActionResult Delete(string postId)
        {
            var featuredTweet = _context.SocialBoardTweets.FirstOrDefault(x => x.IdString == postId);
            if (featuredTweet == null)
            {
                return NotFound();
            }

            _context.SocialBoardTweets.Remove(featuredTweet);
            _context.SaveChanges();
            return Ok();
        }
    }
}
