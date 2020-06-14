using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialWebApi.Models;

namespace SocialWebApi.Controllers
{
    /// <summary>
    /// Save and get featured tweets in project database
    /// </summary>

    // api/post
    [ApiController]
    [Route("api/[controller]")]    
    public class PostController : ControllerBase, IDisposable
    {
        private readonly IMapper _mapper;
        private readonly SocialContext _context;
        private readonly TwitterQuery _tw;

        public PostController(IMapper mapper, SocialContext context)
        {
            _tw = new TwitterQuery();
            _mapper = mapper;
            _context = context;         
        }

        [HttpGet]
        public IActionResult Get()
        {
            // get featured posts
            var json = _context.SocialBoardTweets;
            return Ok(json);
        }

        [HttpGet("tweets/id/{id}")]
        public ActionResult<Tweets> GetTweetById(string id)
        {
            var tweet = _tw.GetTweet(Convert.ToUInt64(id));
            List<TweetsDto> query = _mapper.Map<List<TweetsDto>>(tweet);

            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }

        // add post to featured post grid
        // POST api/post
        [HttpPost]
        public IActionResult Post([FromBody] TweetsDto model)
        { 
            if (ModelState.IsValid)
            {
                var tweet = _mapper.Map<Tweets>(model);
                tweet.DateAdded = DateTime.Now;
                tweet.Id = model.Id;
                tweet.UserId = model.User.UserIDResponse;
                tweet.Username = model.User.Name;
                tweet.ScreenName = model.User.ScreenNameResponse;
                tweet.ProfileImageUrl = model.User.ProfileImageUrlHttps;

                _context.SocialBoardTweets.Add(tweet);
                _context.SaveChanges();

                return NoContent();
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("{postId}")]
        public IActionResult Delete(long postId)
        {
            var featuredTweet = _context.SocialBoardTweets.FirstOrDefault(x => x.Id == postId);
            if (featuredTweet == null)
            {
                return NotFound();
            }

            _context.SocialBoardTweets.Remove(featuredTweet);
            _context.SaveChanges();
            return Ok();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
