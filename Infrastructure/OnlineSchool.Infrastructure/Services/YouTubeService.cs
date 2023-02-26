using OnlineSchool.App.Common.Interfaces.Services;
using System.Net.Http.Json;

namespace OnlineSchool.Infrastructure.Services;

public class YouTubeService : IYouTubeService
{
    private const string YOU_TUBE_API_URL = "https://youtube.googleapis.com/youtube/v3";
    private const string API_KEY = "AIzaSyBa0PWVV4-_zKEnIiXPsDXVyH4gNRjmrzA";

    public async Task<string> GetEmbedCodeByLink(string linkVideo)
    {
        var videoId = GetIdVideoByLink(linkVideo);
        var url = $"{YOU_TUBE_API_URL}/videos?part=player&id={videoId}&key={API_KEY}";

        var response = await new HttpClient().GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var youTubeVideo = await response.Content.ReadFromJsonAsync<YouTubeVideo>();

            return youTubeVideo.Items.FirstOrDefault().Player.EmbedHtml;
        }

        return null;
    }

    private string GetIdVideoByLink(string linkVideo)
    {
        return "GxwKsfZAP8A";
    }
}