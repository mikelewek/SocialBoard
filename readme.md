# SocialBoard
Displays social media posts based on user curated posts

Provides ability to search for posts with terms, hashtags, or post id. The user clicks on button to feature a post which adds it to the live feed for public consumption.

##### The project uses
* .NET Core 2.2
* REST
* React
* Less
* [LinqToTwitter](https://github.com/JoeMayo/LinqToTwitter)

##### Creating database tables
> dotnet ef database update


##### Running the React project
<pre>
<code>$ cd socialboard-app</code>
<code>$ yarn</code>
<code>$ yarn start</code>
</pre>

##### Deploying gh-pages branch
* Change the HashRouting paths in Header.js and Home.js. Example below:
> /SocialBoard/#/search

##### Deploying to gh-pages branch
<pre>
	<code>$ npm run deploy</code>
</pre>

##### To-Do
* Fix screename and id searches
* Integrate Insta posts
* Auto-update featured and live boards every n seconds
* Refine style
* Ordering tiles
