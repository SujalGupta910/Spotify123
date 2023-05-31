using Microsoft.AspNetCore.Authentication.Cookies;
using Spotify123;
using SpotifyAPI.Web;
using static SpotifyAPI.Web.Scopes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var services = builder.Services;
services.AddHttpContextAccessor();
      services.AddSingleton(SpotifyClientConfig.CreateDefault());
      services.AddScoped<SpotifyClientBuilder>();

      services.AddAuthorization(options =>
      {
        options.AddPolicy("Spotify", policy =>
        {
          policy.AuthenticationSchemes.Add("Spotify");
          policy.RequireAuthenticatedUser();
        });
      });
      services
        .AddAuthentication(options =>
        {
          options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(options =>
        {
          options.ExpireTimeSpan = TimeSpan.FromMinutes(50);
        })
        .AddSpotify(options =>
        {
          
          options.ClientId = "clientid";
          options.ClientSecret = "clientsecret";
          options.CallbackPath = "/auth/callback";
          options.SaveTokens = true;

          var scopes = new List<string> {
            UserReadEmail, UserReadPrivate, PlaylistReadPrivate, PlaylistReadCollaborative
          };
          options.Scope.Add(string.Join(",", scopes));
        });
      services.AddRazorPages()
        .AddRazorPagesOptions(options =>
        {
          options.Conventions.AuthorizeFolder("/", "Spotify");
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
