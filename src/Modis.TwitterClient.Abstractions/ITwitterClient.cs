namespace Modis.TwitterClient.Abstractions
{
    using Modis.TwitterClient.Abstractions.Model;

    public interface ITwitterClient
    {
        IAsyncEnumerable<Tweet> GetTweetStream(CancellationToken cancellationToken = default);
    }
}