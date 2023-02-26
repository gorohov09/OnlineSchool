namespace OnlineSchool.Infrastructure.Services;

public class YouTubeVideo
{
    public List<Item> Items { get; set; }
}

public class Item 
{
    public Player Player { get; set; }
}

public class Player
{
    public string EmbedHtml { get; set; }
}