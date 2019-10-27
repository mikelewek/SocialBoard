using System.Collections.Generic;
using LinqToTwitter;
using System.Linq;
using Newtonsoft.Json;
using System;
using System.Text;

namespace SocialWebApi.Models
{
    public class TwitterQuery
    {
        private readonly TwitterContext _ctx;
        public TwitterQuery()
        {
            SingleUserAuthorizer auth = Auth();
            _ctx = new TwitterContext(auth);
        }

        public List<SocialBoardTweets> GetTweet(ulong id)
        {
            //var ttt = (from tt in _ctx.Status
                       //where tt.Type == StatusType.Show
                       //&& tt.ID == id
                       //&& tt.TweetMode == TweetMode.Extended
                       //&& tt.IncludeEntities == true
                       //select tt).ToList();

            List <SocialBoardTweets> query = new List<SocialBoardTweets>();
            try
            {
                query = (from t in _ctx.Status
                 where t.Type == StatusType.Show 
                 && t.ID == id
                 && t.TweetMode == TweetMode.Extended
                 && t.IncludeEntities == true
                 select new SocialBoardTweets
				 {
					 Id = (long)t.ID,
                     IdString = t.ID.ToString(),
					 User = t.User,
					 FullText = FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
                     CreatedAt = t.CreatedAt,
					 FavoritedCount = (int)t.FavoriteCount,
                     RetweetCount = t.RetweetCount,
                     ExtendedEntities = t.ExtendedEntities,
                     MediaUrl = SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                 }).ToList();
            }
            catch (Exception e) 
            {
                // invalid twitter id will error out
                query = null;
            }

			return query;
        }

		public List<SocialBoardTweets> GetUserTweet(string username)
		{
			return (from t in _ctx.Status
					where t.Type == StatusType.User
						&& t.ScreenName == username
						&& t.Count == 30
						&& t.TweetMode == TweetMode.Extended
						&& t.IncludeEntities == true
					select new SocialBoardTweets
					{
						Id = (long)t.ID,
                        IdString = t.ID.ToString(),
                        User = t.User,
						FullText = FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
                        CreatedAt = t.CreatedAt,
						FavoritedCount = (int)t.FavoriteCount,
                        RetweetCount = t.RetweetCount,
                        ExtendedEntities = t.ExtendedEntities,
                        MediaUrl = SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                    }).ToList();
		}

        public IEnumerable<SocialBoardTweets> GetTweetsByTerm(string term)
        {
		IEnumerable<SocialBoardTweets> query = (from search in _ctx.Search
                         where search.Type == SearchType.Search
                         && search.Query == $"\"{term}\""
                         && search.Count == 30
                         && search.TweetMode == TweetMode.Extended
                         && search.IncludeEntities == true
                         select new 
                         {
                             search.Statuses,
                             search.Count,
                         }).Select( x => new 
                         {
                            Statuses = x.Statuses.Select( 
                                t => new SocialBoardTweets
								{
									Id = (long)t.StatusID,
                                    IdString = t.StatusID.ToString(),
                                    User = t.User,
									FullText = FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
                                    CreatedAt = t.CreatedAt,
									FavoritedCount = (int)t.FavoriteCount,
                                    RetweetCount = t.RetweetCount,
                                    ExtendedEntities = t.ExtendedEntities,
                                    MediaUrl = SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                                }),
                                x.Count
                             }).FirstOrDefault().Statuses;

			// serialize combined list into string
			return query;
        }

        public IEnumerable<SocialBoardTweets> GetTweetsByUsername(string username)
        {
			IEnumerable<SocialBoardTweets> query = (from t in _ctx.Status
						 where t.Type == StatusType.User
						 && t.ScreenName == username
						 && t.Count == 30
						 && t.TweetMode == TweetMode.Extended
						 && t.IncludeEntities == true		 
						 select new SocialBoardTweets
						 {
							Id = (long)t.StatusID,
                            IdString = t.StatusID.ToString(),
							User = t.User,
							FullText = FilterTags(t.FullText, t.Entities, t.ExtendedEntities),
							CreatedAt = t.CreatedAt,
							FavoritedCount = (int)t.FavoriteCount,
                            RetweetCount = t.RetweetCount,
                            ExtendedEntities = t.ExtendedEntities,
                            MediaUrl = SetMediaUrls(t.Entities.MediaEntities, t.ExtendedEntities.MediaEntities),
                         });

            // serialize combined list into string
            return query;
        }

        /// <summary>
        /// Replace media, tags, symbols, and links in fulltext.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string FilterTags(string text, Entities entities, Entities extendedEntities)
        {
            // remove media string if media urls exist 
            List<MediaEntity> media = entities.MediaEntities;
            media.AddRange(extendedEntities.MediaEntities);
            if (media.Any())
            {
               text = text.Replace(media[0].Url, string.Empty);
            }

            List<HashTagEntity> hashtags = entities.HashTagEntities;
            hashtags.AddRange(extendedEntities.HashTagEntities);
            foreach (var h in hashtags.Distinct())
            {
                text = text.Replace("#" + h.Text + " ", $"#<a href='https://twitter.com/hashtag/{h.Text}?src=hash/' target='_blank'>{h.Text}</a> ");
            }

            List<SymbolEntity> symbols = entities.SymbolEntities;
            symbols.AddRange(extendedEntities.SymbolEntities);
            foreach (var s in symbols.Distinct())
            {
                text = text.Replace(s.Text + " ", $"<a href='https://twitter.com/{s.Text}' target='_blank'>{s.Text}</a> ");
            }

            List<UrlEntity> urls = entities.UrlEntities;
            urls.AddRange(extendedEntities.UrlEntities);
            foreach (var u in urls.Distinct())
            {
                text = text.Replace(u.Url, $"<a href='{u.Url}' target='_blank'>{u.DisplayUrl}</a>");
            }

            List<UserMentionEntity> mentions = entities.UserMentionEntities;
            mentions.AddRange(extendedEntities.UserMentionEntities);
            foreach (var u in mentions.Distinct())
            {
                text = text.Replace(u.ScreenName + " ", $"<a href='https://twitter.com/{u.ScreenName}' target='_blank'>{u.ScreenName}</a> ");
            }

            return text;
        }

        private string SetMediaUrls(List<MediaEntity> media, List<MediaEntity> extMedia)
        {
            media.AddRange(extMedia);
            var _media = media.GroupBy(x => x.ID).Select(x => x.FirstOrDefault());

            StringBuilder mediaUrlStr = new StringBuilder();
            int i = 0;
            foreach (var m in _media)
            {
                mediaUrlStr.Append($"<a class='media {m.Type} index-{i}' data-count='{_media.Count()}' href='{m.MediaUrl}' target='_blank'><img src='{m.MediaUrl}' /></a>");
                i++;
            }

            return mediaUrlStr.ToString();
        }

        private SingleUserAuthorizer Auth()
        {
            return new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = "xxx",
                    ConsumerSecret = "xxx",
                    AccessToken = "xxx",
                    AccessTokenSecret = "xxx"
                }
            };
        }
    }
}
