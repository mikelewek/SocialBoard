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
> dotnet ef database update InitialCreate

##### Quick fix for running React App with .NET
* A CORS extension for Chrome is needed during dev for different port usage

<pre>
<code>$ cd socialboard-app</code>
<code>$ yarn</code>
<code>$ yarn start</code>
</pre>


##### To-Do
* Integrate Insta posts
* Auto-update featured and live boards every n seconds
* Refine style