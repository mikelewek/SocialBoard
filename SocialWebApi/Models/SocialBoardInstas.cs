using System;

namespace SocialWebApi.Models
{
    public class SocialBoardInstas
    {
        public int Id { get; set; }
        public string Pk { get; set; }
        public string CreatedAt { get; set; }
        public DateTime CreatedAtDateTime { get; set; }
        public string User { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }
        public DateTime TakenAt { get; set; }
        public int LikesCount { get; set; }
        public int? MediaType { get; set; }
        public string MainImageVideo { get; set; }
        public string InstaIdentifier { get; set; }
        public int Width { get; set; }
        public string Height { get; set; }
        public int? ViewCount { get; set; }
        public string Caption { get; set; }
        public DateTime? DeviceTimeStamp { get; set; }
    }
}
