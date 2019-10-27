using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialBoardTweets",
                columns: table => new
                {
                    SocialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Order = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    FollowersCount = table.Column<int>(nullable: false),
                    FriendsCount = table.Column<int>(nullable: false),
                    InReplyToStatusId = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    InReplyToScreenName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    RetweetCount = table.Column<int>(nullable: false),
                    FavoritedCount = table.Column<int>(nullable: false),
                    MediaURL = table.Column<string>(unicode: false, nullable: true),
                    ID = table.Column<long>(nullable: false),
                    PossiblySensitive = table.Column<bool>(nullable: false),
                    SinceID = table.Column<long>(nullable: true),
                    MaxID = table.Column<long>(nullable: true),
                    IdString = table.Column<string>(unicode: false, nullable: false),
                    CreatedAtString = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FullText = table.Column<string>(nullable: false),
                    MediaType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Username = table.Column<string>(nullable: false),
                    ScreenName = table.Column<string>(maxLength: 100, nullable: false),
                    ProfileImageUrl = table.Column<string>(unicode: false, nullable: false),
                    UserId = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialBoardTweets", x => x.SocialID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialBoardTweets");
        }
    }
}
