namespace Modis.TwitterClient.Abstractions
{
    using Modis.TwitterClient.Abstractions.Model;

    public interface ITwitterClient
    {
        IAsyncEnumerable<Twit> GetTweetStream(CancellationToken cancellationToken = default);
    }
}