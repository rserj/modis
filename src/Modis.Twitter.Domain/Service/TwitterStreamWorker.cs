namespace Modis.Twitter.Domain.Service;

using System.Collections.Concurrent;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using Modis.Twitter.Domain.Abstractions;
using Modis.Twitter.Domain.Utils;
using Modis.TwitterClient.Abstractions;

public class TwitterStreamWorker: ITwitterStreamWorker
{
    private const int TrackMaxTags = 10;

    private readonly ITwitterClient _twitterClient;
    private IMemoryCache _memoryCache;
    private readonly ILogger<TwitterStreamWorker> _logger;
    private ConcurrentDictionary<string, int> _map = new();

    public TwitterStreamWorker(ITwitterClient twitterClient, IMemoryCache memoryCache, ILogger<TwitterStreamWorker> logger)
    {
        _twitterClient = twitterClient;
        _memoryCache = memoryCache;
        this._logger = logger;
    }

    public async void WatchTwitterStream(CancellationToken cts)
    {
        ulong tweetCount = 0;
        await foreach (var tweet in this._twitterClient.GetTweetStream(cts))
        {
            tweetCount++;
            var tags = HashTagParser.GetTweetTags(tweet.Text);
            foreach (var tag in tags)
            {
                // keep track of #tag count
                _memoryCache.TryGetValue(tag, out int tagCount);
                this._memoryCache.Set(tag, ++tagCount);

                // tracking uniq tag
                _map[tag] = tagCount;

                // maintaining top #10 items
                if (this._map.Count > TrackMaxTags)
                    _map.TryRemove(this._map.MinBy(pair => pair.Value));

                Print(tweetCount, _map.Keys);
            }
        }
    }

    public virtual void Print(ulong twitCount, IEnumerable<string> topHashes)
    {
        this._logger.LogInformation("total twits: {count}", twitCount);
        this._logger.LogInformation("top #10: {top}", string.Join(',',topHashes));
    }
}