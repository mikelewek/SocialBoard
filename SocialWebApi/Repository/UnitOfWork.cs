using System;
using SocialWebApi;
using SocialWebApi.Models;

namespace SocialWebApi.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly SocialContext _context = new SocialContext();
        private GenericRepository<SocialBoardTweets> tweetRepository;

        public GenericRepository<SocialBoardTweets> TweetRepository
        {
            get
            {
                if (tweetRepository == null)
                {
                    tweetRepository = new GenericRepository<SocialBoardTweets>(_context);
                }
                return tweetRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
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