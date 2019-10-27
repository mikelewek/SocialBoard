﻿using Microsoft.EntityFrameworkCore;

namespace SocialWebApi.Models
{
    public class SocialContext : DbContext
    {
        public virtual DbSet<SocialBoardTweets> SocialBoardTweets { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // docker 
            // optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SocialBoard;MultipleActiveResultSets=true;integrated security=False;User ID=xxx;Password=xxx;");

            // azure
            optionsBuilder.UseSqlServer("Server=sqlazure01lewek.database.windows.net;Database=SocialBoard;MultipleActiveResultSets=true;integrated security=False;User ID=xxx;Password=xxx;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<SocialBoardTweets>(entity =>
            {
                entity.HasKey(e => e.SocialId);

                entity.Property(e => e.SocialId).HasColumnName("SocialID");

                entity.Property(e => e.CreatedAtString)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullText).IsRequired();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdString)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.InReplyToScreenName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InReplyToStatusId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaxId).HasColumnName("MaxID");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MediaUrl)
                    .HasColumnName("MediaURL")
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImageUrl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ScreenName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SinceId).HasColumnName("SinceID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired();
            });
        }
    }
}
