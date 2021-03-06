# SocialBoard
Displays social media posts based on user curated posts.

Provides ability to search for posts with terms, hashtags, or post id. The user clicks on button to feature a post which adds it to the live feed for public consumption.


##### The project uses
* .NET Core 3
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
* appsettings in root of .net project has been removed 
* Cache post data to prevent unecessary calls
* .less file issue caused by Hashrouter unless published to Azure
* Add loading images when searching and updating page
* Fix for multiple images in posts 
* Integrate Insta posts
* Auto-update featured and live boards every n seconds
* Refine style
* Ordering tiles
* Option to automatically remove older featured posts over screen height
* Matching featured with search results doesn't look like it should work
* Cleanup TypeScript datatype any 
* CORS config 


##### Secrets File for Database Connection and API Strings
https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
