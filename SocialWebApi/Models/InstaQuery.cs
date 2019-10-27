using System;
using InstaSharper;
using InstaSharper.API;
using System.Linq;
using System.Threading.Tasks;
using InstaSharper.Classes;
using System.Collections.Generic;
using InstaSharper.Classes.Models;
using InstaSharper.API.Builder;
using InstaSharper.Logger;
using System.IO;

namespace SocialWebApi.Models
{
    public class InstaQuery
    {
        private IInstaApi _instaApi { get; set; }

        public async Task<List<InstaMedia>> GetInstaByTag(string term)
        {
            var currentUser = await _instaApi.GetCurrentUserAsync();
            var tagFeed = await _instaApi.GetTagFeedAsync(term, PaginationParameters.MaxPagesToLoad(1));

            if (tagFeed.Succeeded)
            {
                List<InstaMedia> media = tagFeed.Value.Medias.Take(20).ToList();
                return media;
            }
            return null;
        }

        public async Task Auth()
        {
            var userSession = new UserSessionData
            {
                UserName = "xxx",
                Password = "xxx"
            };

            var delay = RequestDelay.FromSeconds(2, 2);
            // create new InstaApi instance using Builder
            _instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.Exceptions)) // use logger for requests and debug messages
                .SetRequestDelay(delay)
                .Build();

            const string stateFile = "state.bin";
            try
            {
                if (File.Exists(stateFile))
                {
                    using (var fs = File.OpenRead(stateFile))
                    {
                        _instaApi.LoadStateDataFromStream(fs);
                    }
                }
            }
            catch (Exception e){}

            if (!_instaApi.IsUserAuthenticated)
            {
                // login
                delay.Disable();
                var logInResult = await _instaApi.LoginAsync();
                delay.Enable();
                if (!logInResult.Succeeded)
                {
                    // return Content($"Unable to login: {logInResult.Info.Message}");
                }
            }
            var state = _instaApi.GetStateDataAsStream();
            using (var fileStream = File.Create(stateFile))
            {
                state.Seek(0, SeekOrigin.Begin);
                state.CopyTo(fileStream);
            }
        }

        public async Task<InstaMedia> GetInstaById(string mediaId)
        {
            var currentUser = await _instaApi.GetCurrentUserAsync();
            var mediaPost = await _instaApi.GetMediaByIdAsync(mediaId);

            if (mediaPost.Succeeded)
            {
                var media = mediaPost.Value;
                return media;
            }
            return null;
        }

        public async Task<List<InstaMedia>> GetInstaByUsername(string screename)
        {
            var currentUser = await _instaApi.GetCurrentUserAsync();
            var tagFeed = await _instaApi.GetUserTimelineFeedAsync(PaginationParameters.MaxPagesToLoad(1));

            if (tagFeed.Succeeded)
            {
                List<InstaMedia> media = tagFeed.Value.Medias.Take(20).ToList();
                return media;
            }
            return null;
        }
    }
}