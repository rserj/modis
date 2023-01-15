namespace Modis.TwitterClient.Abstractions
{
    using Modis.TwitterClient.Abstractions.Model;

    /// <summary>
    /// Tweeter web client
    /// </summary>
    public interface ITwitterClient
    {
        /// <summary>
        /// Consume async tweets stream
        /// </summary>
        /// <param name="cancellationToken">A token which stops streaming</param>
        /// <returns>Asynchronous stream of tweets</returns>
        IAsyncEnumerable<Tweet> GetTweetStream(CancellationToken cancellationToken = default);
    }
}