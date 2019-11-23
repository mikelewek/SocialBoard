using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using LinqToTwitter;

namespace SocialWebApi.Models
{
    [AutoMap(typeof(SocialBoardTweets))]
    public class SocialBoardTweetsDto
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


        public bool IncludeRetweets { get; set; }

        public bool ExcludeReplies { get; set; }

        public bool IncludeEntities { get; set; }

        public User User { get; set; }

        public Entities Entities { get; set; }

        public Entities ExtendedEntities { get; set; }

        public Status RetweetedStatus { get; set; }

        public Status ExtendedTweet { get; set; }

        public string Source { get; set; }

        public bool IsFeatured { get; set; }

        public string IdString { get; set; }

        private string _createdAtString;
        public string CreatedAtString
        {
            get
            {
                return CreatedAt.AddHours(-5).ToString("hh:mm tt - dd MMM yyyy");
            }
            set
            {
                _createdAtString = value;
            }
        }

        public string FullText { get; set; }

        private string _mediaType;
        public string MediaType
        {
            get
            {
                return Entities != null && Entities.MediaEntities.Count > 0 ? Entities.MediaEntities[0].Type : _mediaType;
            }
            set { _mediaType = value; }
        }

        private string _userName;
        public string Username
        {
            get
            {
                return User != null ? User.Name : _userName;
            }
            set { _userName = value; }
        }

        private string _screenName;
        public string ScreenName
        {
            get
            {
                return User != null ? User.ScreenNameResponse : _screenName;
            }
            set { _screenName = value; }
        }

        private string _profileImageUrl;
        public string ProfileImageUrl
        {
            get
            {
                return User != null ? User.ProfileImageUrl : _profileImageUrl;
            }
            set { _profileImageUrl = value; }
        }

        private string _userId;
        public string UserId
        {
            get
            {
                return User != null ? User.UserID.ToString() : _userId;
            }
            set { _userId = value; }
        }
    }
}
