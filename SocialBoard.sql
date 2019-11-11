-- Database export via SQLPro (https://www.sqlprostudio.com/allapps.html)
-- Exported by mike at 09-11-2019 23:44.
-- WARNING: This file may contain descructive statements such as DROPs.
-- Please ensure that you are running the script at the proper location.


-- BEGIN TABLE dbo.__EFMigrationsHistory
IF OBJECT_ID('dbo.__EFMigrationsHistory', 'U') IS NOT NULL
DROP TABLE dbo.__EFMigrationsHistory;
GO

CREATE TABLE dbo.__EFMigrationsHistory (
	MigrationId nvarchar(150) NOT NULL,
	ProductVersion nvarchar(32) NOT NULL
);
GO

ALTER TABLE dbo.__EFMigrationsHistory ADD CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId);
GO

-- Inserting 1 row into dbo.__EFMigrationsHistory
-- Insert batch #1
INSERT INTO dbo.__EFMigrationsHistory (MigrationId, ProductVersion) VALUES
('20191018005211_InitialCreate', '2.2.6-servicing-10079');

-- END TABLE dbo.__EFMigrationsHistory

-- BEGIN TABLE dbo.SocialBoardTweets
IF OBJECT_ID('dbo.SocialBoardTweets', 'U') IS NOT NULL
DROP TABLE dbo.SocialBoardTweets;
GO

CREATE TABLE dbo.SocialBoardTweets (
	SocialID int NOT NULL IDENTITY(1,1),
	[Order] int NOT NULL,
	CreatedAt datetime2(8) NOT NULL,
	DateAdded datetime2(8) NOT NULL,
	FollowersCount int NOT NULL,
	FriendsCount int NOT NULL,
	InReplyToStatusId varchar(100) NULL,
	InReplyToScreenName varchar(100) NULL,
	RetweetCount int NOT NULL,
	FavoritedCount int NOT NULL,
	MediaURL varchar(max) NULL,
	ID bigint(8) NOT NULL,
	PossiblySensitive bit NOT NULL,
	SinceID bigint(8) NULL,
	MaxID bigint(8) NULL,
	IdString varchar(max) NOT NULL,
	CreatedAtString varchar(50) NOT NULL,
	FullText nvarchar(max) NOT NULL,
	MediaType varchar(50) NULL,
	Username nvarchar(max) NOT NULL,
	ScreenName nvarchar(100) NOT NULL,
	ProfileImageUrl varchar(max) NOT NULL,
	UserId varchar(max) NOT NULL
);
GO

ALTER TABLE dbo.SocialBoardTweets ADD CONSTRAINT PK_SocialBoardTweets PRIMARY KEY (SocialID);
GO

-- Inserting 16 rows into dbo.SocialBoardTweets
-- Insert batch #1
INSERT INTO dbo.SocialBoardTweets (SocialID, [Order], CreatedAt, DateAdded, FollowersCount, FriendsCount, InReplyToStatusId, InReplyToScreenName, RetweetCount, FavoritedCount, MediaURL, ID, PossiblySensitive, SinceID, MaxID, IdString, CreatedAtString, FullText, MediaType, Username, ScreenName, ProfileImageUrl, UserId) VALUES
(9, 0, '2019-10-26 04:31:49.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 0, '', 1187949932558409700, 0, NULL, NULL, '1187949932558409728', '11:31 PM - 25 Oct 2019', 'I say pressure immediately swings to @Nationals. If Washington loses, it''s 2-2 with @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> and @<a href=''https://twitter.com/JustinVerlander'' target=''_blank''>JustinVerlander</a> next...and a prospective game 7 in Houston. If @<a href=''https://twitter.com/astros'' target=''_blank''>astros</a> lose, difficult down 3-1, but still have all that lined up. Pressure at the least equal. @MLBONFOX', NULL, 'Bryan Rivera', 'weekoldsushi', 'http://pbs.twimg.com/profile_images/1185445038119182337/F2CnFNZ9_normal.jpg', '0'),
(10, 0, '2019-10-26 01:02:27.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 0, '<a class=''media photo index-0'' data-count=''1'' href=''http://pbs.twimg.com/media/EHxCPfkWsAAOn-W.jpg'' target=''_blank''><img src=''http://pbs.twimg.com/media/EHxCPfkWsAAOn-W.jpg'' /></a>', 1187897243678003200, 0, NULL, NULL, '1187897243678003200', '08:02 PM - 25 Oct 2019', 'We got this!!!@astros @<a href=''https://twitter.com/kateyy_86'' target=''_blank''>kateyy_86</a> @<a href=''https://twitter.com/JoseAltuve27'' target=''_blank''>JoseAltuve27</a> @<a href=''https://twitter.com/gvtalk'' target=''_blank''>gvtalk</a> @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> @<a href=''https://twitter.com/robertreidryan'' target=''_blank''>robertreidryan</a> ', NULL, 'Kyle Griswold', 'KyleDGriswold', 'http://pbs.twimg.com/profile_images/596533976635973632/KWm_Fz1f_normal.jpg', '0'),
(11, 0, '2019-10-26 04:24:07.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 1, '<a class=''media photo index-0'' data-count=''1'' href=''http://pbs.twimg.com/media/EHxwZwMX4AA35uF.jpg'' target=''_blank''><img src=''http://pbs.twimg.com/media/EHxwZwMX4AA35uF.jpg'' /></a>', 1187947995251314700, 0, NULL, NULL, '1187947995251314688', '11:24 PM - 25 Oct 2019', 'Were all a Big happy family. @<a href=''https://twitter.com/astros'' target=''_blank''>astros</a> @<a href=''https://twitter.com/JoseAltuve27'' target=''_blank''>JoseAltuve27</a> @<a href=''https://twitter.com/el_yuly10'' target=''_blank''>el_yuly10</a> @<a href=''https://twitter.com/JustinVerlander'' target=''_blank''>JustinVerlander</a> @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> @<a href=''https://twitter.com/ABREG_1'' target=''_blank''>ABREG_1</a> ', NULL, 'Jessica', 'Jessica80228373', 'http://pbs.twimg.com/profile_images/1187209917326864384/AOfEXQU-_normal.jpg', '0'),
(12, 0, '2019-10-26 01:24:51.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 39, 0, '', 1187902879744581600, 0, NULL, NULL, '1187902879744581633', '08:24 PM - 25 Oct 2019', 'RT @MLBTheShow: FINEST SET 3 IS LIVE!\nSee it all here: <a href=''https://t.co/forhAIUCfs'' target=''_blank''>theshow.gg/b9dt</a>\n💎99 OVR, @Astros Starting Pitcher, @GerritCole45!\n#TheShowFi…', NULL, 'Garrick Chavez', 'JTsFrostedTipss', 'http://pbs.twimg.com/profile_images/439820425334243328/3bm5ghCw_normal.jpeg', '0'),
(13, 0, '2019-10-26 00:03:49.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 39, 0, '', 1187882486459785200, 0, NULL, NULL, '1187882486459785221', '07:03 PM - 25 Oct 2019', 'RT @MLBTheShow: FINEST SET 3 IS LIVE!\nSee it all here: <a href=''https://t.co/forhAIUCfs'' target=''_blank''>theshow.gg/b9dt</a>\n💎99 OVR, @Astros Starting Pitcher, @GerritCole45!\n#TheShowFi…', NULL, '🎃James Conner Stan Account👻', 'BillsMafia178', 'http://pbs.twimg.com/profile_images/1183535378172542976/y5HkedMG_normal.jpg', '0'),
(14, 0, '2019-10-26 01:17:22.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 3, '<a class=''media photo index-0'' data-count=''1'' href=''http://pbs.twimg.com/media/EHxFqVAXYAE0Ga3.jpg'' target=''_blank''><img src=''http://pbs.twimg.com/media/EHxFqVAXYAE0Ga3.jpg'' /></a>', 1187900998666375200, 0, NULL, NULL, '1187900998666375168', '08:17 PM - 25 Oct 2019', '@<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> Is so Pretty 😍#<a href=''https://twitter.com/hashtag/Astros?src=hash/'' target=''_blank''>Astros</a> #<a href=''https://twitter.com/hashtag/worldseries?src=hash/'' target=''_blank''>worldseries</a> #<a href=''https://twitter.com/hashtag/HTownPride?src=hash/'' target=''_blank''>HTownPride</a>  Lets Go Astros ⚾️⚾️⚾️⚾️❣️ ', NULL, '🅰️That Bama ~Texas 🏈', 'That_Bama_Texas', 'http://pbs.twimg.com/profile_images/1051082498447462401/m76dB2bd_normal.jpg', '0'),
(15, 0, '2019-10-25 23:00:10.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 0, '', 1187866469742174200, 0, NULL, NULL, '1187866469742174208', '06:00 PM - 25 Oct 2019', 'Just watched an interview w/ @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> on @<a href=''https://twitter.com/MLBNetwork'' target=''_blank''>MLBNetwork</a> have been a fan of the player for sure, now I’m a fan of the man. Very humble down to earth guy. Best of luck to you!', NULL, 'Coach Scotty Yount', 'syount04', 'http://pbs.twimg.com/profile_images/1169013987872247816/9h2ntH10_normal.jpg', '0'),
(16, 0, '2019-10-26 01:13:27.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 0, '', 1187900009452310500, 0, NULL, NULL, '1187900009452310528', '08:13 PM - 25 Oct 2019', '@<a href=''https://twitter.com/MegaTebow'' target=''_blank''>MegaTebow</a> @<a href=''https://twitter.com/MLBTheShow'' target=''_blank''>MLBTheShow</a> @<a href=''https://twitter.com/astros'' target=''_blank''>astros</a> @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> Edmonds is a stud I agree. He’s the first off the bench against righties.', NULL, 'Alex Czernewski', 'Zeusy24', 'http://pbs.twimg.com/profile_images/1042025972621631488/VxcCWRjT_normal.jpg', '0'),
(17, 0, '2019-10-26 03:56:10.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 2, '', 1187940961592021000, 0, NULL, NULL, '1187940961592020992', '10:56 PM - 25 Oct 2019', 'En lo personal yo pondría mañana a @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> como abridor para tratar de emparejar la serie.\n\nCole al 90% mucho mejor que cualquier otro al 100%.\n\n¿Qué opinan ustedes?\n\nLos leo', NULL, 'TUCAPICKS (Sport Investor)', 'ElTucaPicks', 'http://pbs.twimg.com/profile_images/1164789407603277825/WW0q9SDL_normal.jpg', '0'),
(18, 0, '2019-10-25 22:57:26.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 39, 0, '', 1187865782883106800, 0, NULL, NULL, '1187865782883106816', '05:57 PM - 25 Oct 2019', 'RT @MLBTheShow: FINEST SET 3 IS LIVE!\nSee it all here: <a href=''https://t.co/forhAIUCfs'' target=''_blank''>theshow.gg/b9dt</a>\n💎99 OVR, @Astros Starting Pitcher, @GerritCole45!\n#TheShowFi…', NULL, '💀⚾Bigtomk22⚾💀', 'Bigtomk22YT', 'http://pbs.twimg.com/profile_images/1047325324873220096/ABA2lpAJ_normal.jpg', '0'),
(19, 0, '2019-10-25 21:54:46.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 39, 0, '', 1187850011742277600, 0, NULL, NULL, '1187850011742277634', '04:54 PM - 25 Oct 2019', 'RT @MLBTheShow: FINEST SET 3 IS LIVE!\nSee it all here: <a href=''https://t.co/forhAIUCfs'' target=''_blank''>theshow.gg/b9dt</a>\n💎99 OVR, @Astros Starting Pitcher, @GerritCole45!\n#TheShowFi…', NULL, 'Cameron LaBarge', 'cdizzle02', 'http://pbs.twimg.com/profile_images/1102743346857107462/3_ungEHZ_normal.jpg', '0'),
(23, 0, '2019-10-27 04:07:05.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 2, '<a class=''media photo index-0'' data-count=''1'' href=''http://pbs.twimg.com/tweet_video_thumb/EH22Fr1WsAAw7nO.jpg'' target=''_blank''><img src=''http://pbs.twimg.com/tweet_video_thumb/EH22Fr1WsAAw7nO.jpg'' /></a>', 1188306095648977000, 0, NULL, NULL, '1188306095648976897', '11:07 PM - 26 Oct 2019', 'So ur tellin me the series tied 2-2 and we got @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> and @<a href=''https://twitter.com/JustinVerlander'' target=''_blank''>JustinVerlander</a> coming up next!?\n#<a href=''https://twitter.com/hashtag/TakeItBack?src=hash/'' target=''_blank''>TakeItBack</a> ', NULL, 'AgainstTheGrainHOU', 'ATGsportsHou', 'http://pbs.twimg.com/profile_images/1078140765057048576/K6MeEwYa_normal.jpg', '0'),
(24, 0, '2019-10-27 05:22:41.0000000', '0001-01-03 00:00:00.000', 0, 0, NULL, NULL, 0, 0, '', 1188325119866876000, 0, NULL, NULL, '1188325119866875904', '12:22 AM - 27 Oct 2019', '@<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> Sunday is YOUR day! Believe it!', NULL, 'Debbie Rankin', 'dvr4me', 'http://pbs.twimg.com/profile_images/1143373363487944705/G09HdJ0i_normal.png', '0'),
(27, 0, '2019-10-27 04:22:26.0000000', '2019-10-27 02:01:03.9879060', 0, 0, NULL, NULL, 0, 0, '<a class=''media photo index-0'' data-count=''1'' href=''http://pbs.twimg.com/ext_tw_video_thumb/1188309810460188673/pu/img/5V6FMKRlotv-8Wk6.jpg'' target=''_blank''><img src=''http://pbs.twimg.com/ext_tw_video_thumb/1188309810460188673/pu/img/5V6FMKRlotv-8Wk6.jpg'' /></a>', 1188309958615425000, 0, NULL, NULL, '1188309958615425025', '11:22 PM - 26 Oct 2019', '@<a href=''https://twitter.com/astros'' target=''_blank''>astros</a> I fell so y’all could win... You’re welcome @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> #<a href=''https://twitter.com/hashtag/TakeItBack?src=hash/'' target=''_blank''>TakeItBack</a> ', NULL, 'Sunny Souvannarath', 'cloudysunnydays', 'http://pbs.twimg.com/profile_images/1132479358210387968/pfVmi0CX_normal.jpg', '0'),
(28, 0, '2019-10-27 03:44:30.0000000', '2019-10-27 02:01:11.8662910', 0, 0, NULL, NULL, 7, 0, '<a class=''media photo index-0'' data-count=''1'' href=''http://pbs.twimg.com/ext_tw_video_thumb/1188233273551609856/pu/img/jizl41-XZTEcfX6I.jpg'' target=''_blank''><img src=''http://pbs.twimg.com/ext_tw_video_thumb/1188233273551609856/pu/img/jizl41-XZTEcfX6I.jpg'' /></a>', 1188300412383907800, 0, NULL, NULL, '1188300412383907842', '10:44 PM - 26 Oct 2019', 'RT @MarkBermanFox26: .@<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> getting ready for game five. #<a href=''https://twitter.com/hashtag/Astros?src=hash/'' target=''_blank''>Astros</a> @<a href=''https://twitter.com/astros'' target=''_blank''>astros</a> ', NULL, 'DEDE', 'DionMerchant', 'http://pbs.twimg.com/profile_images/1095486276004966400/O1YnBct0_normal.jpg', '0'),
(29, 0, '2019-10-27 04:13:58.0000000', '2019-10-27 02:01:14.2085470', 0, 0, NULL, NULL, 0, 0, '<a class=''media photo index-0'' data-count=''1'' href=''http://pbs.twimg.com/ext_tw_video_thumb/1188307799794769920/pu/img/t7DLVI3HgyUfIibz.jpg'' target=''_blank''><img src=''http://pbs.twimg.com/ext_tw_video_thumb/1188307799794769920/pu/img/t7DLVI3HgyUfIibz.jpg'' /></a>', 1188307829846937600, 0, NULL, NULL, '1188307829846937600', '11:13 PM - 26 Oct 2019', '@<a href=''https://twitter.com/astros'' target=''_blank''>astros</a> @<a href=''https://twitter.com/ABREG_1'' target=''_blank''>ABREG_1</a> @<a href=''https://twitter.com/TeamCJCorrea'' target=''_blank''>TeamCJCorrea</a> @<a href=''https://twitter.com/JOSEALTUVE__27'' target=''_blank''>JOSEALTUVE__27</a> @<a href=''https://twitter.com/JustinVerlander'' target=''_blank''>JustinVerlander</a> @<a href=''https://twitter.com/GerritCole45'' target=''_blank''>GerritCole45</a> @<a href=''https://twitter.com/zackgreinke23'' target=''_blank''>zackgreinke23</a> ', NULL, 'nbanales', 'nbanales77', 'http://pbs.twimg.com/profile_images/1183529993869189120/OGJLxu7D_normal.jpg', '0');

-- END TABLE dbo.SocialBoardTweets

