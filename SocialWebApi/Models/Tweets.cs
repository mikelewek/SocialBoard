using System;
using AutoMapper;

namespace SocialWebApi.Models
{
    [AutoMap(typeof(TweetsDto))]
    public class Tweets : Entity
    {
        public int SocialId { get; set; }

        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DateAdded { get; set; }

        public int FollowersCount { get; set; }

        public int FriendsCount { get; set; }

        public string InReplyToStatusId { get; set; }

        public string InReplyToScreenName { get; set; }

        public int RetweetCount { get; set; } = 0;

        public int FavoritedCount { get; set; } = 0;

        public string MediaUrl { get; set; }

        public bool PossiblySensitive { get; set; }

        public long? SinceId { get; set; }

        public long? MaxId { get; set; }

        public string FullText { get; set; }

        public string MediaType { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public string ScreenName { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}
