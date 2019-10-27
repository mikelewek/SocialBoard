using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialWebApi.Models;
using SocialWebApi.Repositories;

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
        private readonly UnitOfWork _uow;

		public PostController(IMapper mapper)
        {
            _uow = new UnitOfWork();
            _mapper = mapper;
		}

        [HttpGet]
        public IActionResult Get()
        {
            // get featured posts
            // 
            var json = _uow.TweetRepository.Get();
            return Ok(json);
        }

		[HttpGet("tweets/id/{id}")]
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
        public IActionResult Post([FromBody] SocialBoardTweetsDto model)
        {
            if(ModelState.IsValid)
            {
                model.DateAdded = DateTime.Now;
                var tweet = _mapper.Map<SocialBoardTweets>(model);

                _uow.TweetRepository.Insert(tweet);
                _uow.Save();

                return NoContent();
            }

            return BadRequest(ModelState);
            
        }


        [HttpDelete("{postId}")]
        public IActionResult Delete(string postId)
        {
            var featuredTweet = _uow.TweetRepository.Get(x => x.IdString == postId).FirstOrDefault();
            if (featuredTweet == null)
            {
                return NotFound();
            }

            _uow.TweetRepository.Delete(featuredTweet.SocialId);
            _uow.Save();
            return Ok();
        }
    }
}
