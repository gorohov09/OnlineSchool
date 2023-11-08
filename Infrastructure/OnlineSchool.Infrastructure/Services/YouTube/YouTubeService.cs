using Microsoft.Extensions.Options;
using OnlineSchool.App.Common.Interfaces.Services;
using System.Net.Http.Json;
using System.Web;

namespace OnlineSchool.Infrastructure.Services.YouTube;

public class YouTubeService : IYouTubeService
{
    private const string YOU_TUBE_API_URL = "https://youtube.googleapis.com/youtube/v3";

    private readonly YouTubeSettings _youTubeSettings;

    public YouTubeService(IOptions<YouTubeSettings> youTubeSettings)
    {
        _youTubeSettings = youTubeSettings.Value;
    }

    public async Task<string> GetEmbedCodeByLink(string linkVideo)
    {
        var videoId = GetIdVideoByLink(linkVideo);

        if (videoId is not null)
        {
            var url = $"{YOU_TUBE_API_URL}/videos?part=player&id={videoId}&key={_youTubeSettings.API_KEY}";

            var response = await new HttpClient().GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var youTubeVideo = await response.Content.ReadFromJsonAsync<YouTubeVideo>();

                return youTubeVideo.Items.FirstOrDefault().Player.EmbedHtml;
            }
        }

        return null;
    }

    private string GetIdVideoByLink(string linkVideo)
    {
        var uri = new Uri(linkVideo);

        if (uri.Host == "www.youtube.com")
        {
            var query = HttpUtility.ParseQueryString(uri.Query);
            return query["v"];
        }

        return null;
    }
}