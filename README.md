# Lily Chou Chou inspired Spotify webpage
![Website Screenshot](https://github.com/SujalGupta910/SpotifyPlaylistsWeb/blob/master/Spotify123.png)
It's a simple webpage made with ASP.NET core and SpotifyAPI-Net API. 
It uses OAuth to authorise the user with spotify and grant read access. 
Once successfully authorised, the user can view their saved playlists on the webpage, which is themed after the Shunji Iwai coming-of-age
movie All About Lily Chou Chou

# How to run
Make sure you have an app registered with spotify at developers.spotify.com

Open the Program.cs file, and change the options.clientId to your client id and options.clientSecret with your client secret
Make sure the options.callbackpath is appended at the end of the redirect uri in your spotify app's dashboard

Install and add the packages SpotifyAPI.Web and SpotifyAPI.Web.Auth from your package manager
```
dotnet add package SpotifyAPI.Web
dotnet add package SpotifyAPI.Web.Auth
```
run the Spotify123.sln file using the command :
```
dotnet watch
``` 
