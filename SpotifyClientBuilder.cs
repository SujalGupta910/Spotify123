using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SpotifyAPI.Web;

namespace Spotify123;

  public class SpotifyClientBuilder
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly SpotifyClientConfig _spotifyClientConfig;

    public SpotifyClientBuilder(IHttpContextAccessor httpContextAccessor, SpotifyClientConfig spotifyClientConfig)
    {
      _httpContextAccessor = httpContextAccessor;
      _spotifyClientConfig = spotifyClientConfig;
    }

    public async Task<SpotifyClient> BuildClient()
    {
      var httpContext = _httpContextAccessor.HttpContext;
      if(httpContext is null){
        throw new Exception("HttpContext is null");
      }
      var token = await httpContext.GetTokenAsync("Spotify", "access_token");
      if (token is null)
    {
      throw new Exception("Spotify access token is null.");
    }
      
      return new SpotifyClient(_spotifyClientConfig.WithToken(token));
    }
  }
