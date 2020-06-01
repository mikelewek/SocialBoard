using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToTwitter;

namespace SocialWebApi.Models
{
    /// <summary>
    /// Replace media, tags, symbols, and links in fulltext.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>

    public static class ConvertProperties
    {
        public static string FilterTags(string text, Entities entities, Entities extendedEntities)
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

        public static string SetMediaUrls(List<MediaEntity> media, List<MediaEntity> extMedia)
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
    }
}