using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;

namespace SocialWebApi.Models
{
    public class TwitterQuery
    {
        private readonly TwitterContext _ctx;

        public TwitterQuery()
        {
            var auth = Auth();
            _ctx = new TwitterContext(auth);
        }

        public async Task<List<TweetsDto>> GetTweet(ulong id)
        { 
            return await (from t in _ctx.Status
                 where t.Type == StatusType.Show 
                 && t.ID == id
                 && t.TweetMode == TweetMode.Extended
                 && t.IncludeEntities == true
                    select new TweetsDto
                    {
                        Id = (long)t.StatusID,
                        User = t.User,
                        FullText = ConvertProperties.FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
                        CreatedAt = t.CreatedAt,
                        FavoritedCount = (int)t.FavoriteCount,
                        RetweetCount = t.RetweetCount,
                        ExtendedEntities = t.ExtendedEntities,
                        MediaUrl = ConvertProperties.SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                    }).ToListAsync();
        }

		public async Task<List<TweetsDto>> GetUserTweet(string username)
		{
            return await (from t in _ctx.Status
                    where t.Type == StatusType.User
                        && t.ScreenName == username
                        && t.Count == 30
                        && t.TweetMode == TweetMode.Extended
                        && t.IncludeEntities == true
                    select new TweetsDto
                    {
                        Id = (long)t.StatusID,
                        User = t.User,
                        FullText = ConvertProperties.FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
                        CreatedAt = t.CreatedAt,
                        FavoritedCount = (int)t.FavoriteCount,
                        RetweetCount = t.RetweetCount,
                        ExtendedEntities = t.ExtendedEntities,
                        MediaUrl = ConvertProperties.SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                    }).ToListAsync();
        }

              public List<TweetsDto> GetTweetsByTerm(string term)
              {
                return (from search in _ctx.Search
                        where search.Type == SearchType.Search
                        && search.Query == $"\"{term}\""
                        && search.Count == 30
                        && search.TweetMode == TweetMode.Extended
                        && search.IncludeEntities == true
                        select new
                        {
                            search.Statuses,
                            search.Count,
                        }).Select(x => new
                        {
                            Statuses = x.Statuses.Select(
                              t => new TweetsDto
                              {
                                  Id = (long)t.StatusID,
                                  User = t.User,
                                  FullText = ConvertProperties.FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
                                  CreatedAt = t.CreatedAt,
                                  FavoritedCount = (int)t.FavoriteCount,
                                  RetweetCount = t.RetweetCount,
                                  ExtendedEntities = t.ExtendedEntities,
                                  MediaUrl = ConvertProperties.SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                              }),
                            x.Count
                        }).FirstOrDefault().Statuses.ToList();
        }

        public async Task<List<TweetsDto>> GetTweetsByUsernameAsync(string username)
        {
            return await (from t in _ctx.Status
                      where t.Type == StatusType.User
                      && t.ScreenName == username
                      && t.Count == 30
                      && t.TweetMode == TweetMode.Extended
                      && t.IncludeEntities == true
                          select new TweetsDto
                          {
                              Id = (long)t.StatusID,
                              User = t.User,
                              FullText = ConvertProperties.FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
                              CreatedAt = t.CreatedAt,
                              FavoritedCount = (int)t.FavoriteCount,
                              RetweetCount = t.RetweetCount,
                              ExtendedEntities = t.ExtendedEntities,
                              MediaUrl = ConvertProperties.SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                          }).ToListAsync();
        }

        private SingleUserAuthorizer Auth()
        {
            var config = AppSettings.Configuration;

            return new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = config["Twitter:ConsumerKey"],
                    ConsumerSecret = config["Twitter:ConsumerSecret"],
                    AccessToken = config["Twitter:AccessToken"],
                    AccessTokenSecret = config["Twitter:AccessTokenSecret"]
                }
            };
        }
    }
}
