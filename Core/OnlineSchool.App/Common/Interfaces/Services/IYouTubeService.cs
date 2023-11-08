namespace OnlineSchool.App.Common.Interfaces.Services;

public interface IYouTubeService
{
    public Task<string> GetEmbedCodeByLink(string linkVideo);
}
