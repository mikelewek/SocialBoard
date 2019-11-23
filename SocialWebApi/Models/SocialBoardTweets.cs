using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using LinqToTwitter;

namespace SocialWebApi.Models
{
    /// <summary>
    /// Combines LinqToTwitter class to transfer Twitter API data and also save into the database
    /// </summary>
    [AutoMap(typeof(SocialBoardTweetsDto))]
    public class SocialBoardTweets : Entity
    {
        public int SocialId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DateAdded { get; set; }

        public int FollowersCount { get; set; }

        public int FriendsCount { get; set; }

        public string InReplyToStatusId { get; set; }

        public string InReplyToScreenName { get; set; }

        public int RetweetCount { get; set; } = 0;

        public int FavoritedCount { get; set; } = 0;

        public string MediaUrl { get; set; }

        public long Id { get; set; }

        public bool PossiblySensitive { get; set; }

        public long? SinceId { get; set; }

        public long? MaxId { get; set; }

        [NotMapped]
        public bool IncludeRetweets { get; set; }

        [NotMapped]
        public bool ExcludeReplies { get; set; }

        [NotMapped]
        public bool IncludeEntities { get; set; }

        [NotMapped]
        public User User { get; set; }

        [NotMapped]
        public Entities Entities { get; set; }

        [NotMapped]
        public Entities ExtendedEntities { get; set; }

        [NotMapped]
        public Status RetweetedStatus { get; set; }

        [NotMapped]
        public Status ExtendedTweet { get; set; }

        [NotMapped]
        public string Source { get; set; }

        [NotMapped]
        public bool IsFeatured { get; set; }

        public string IdString { get; set; }

        public string CreatedAtString { get; set; }

        public string FullText { get; set; }

        public string MediaType { get; set; }

        public string Username { get; set; }

        public string ScreenName { get; set; }

        public string ProfileImageUrl { get; set; }

        public string UserId { get; set; }
    }
}
