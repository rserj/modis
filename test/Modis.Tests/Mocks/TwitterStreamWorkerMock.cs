namespace Modis.Tests.Mocks;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Modis.Twitter.Domain.Service;
using Modis.TwitterClient.Abstractions;

public class TwitterStreamWorkerMock : TwitterStreamWorker
{
    public List<(int count, List<string> topHashTags)> PrintData { get; } = new();

    public TwitterStreamWorkerMock(ITwitterClient twitterClient, IMemoryCache memoryCache)
        : base(twitterClient, memoryCache, new NullLogger<TwitterStreamWorker>())
    {
    }

    protected override void Print(int twitCount, IEnumerable<string> topHashes)
    {
        PrintData.Add((twitCount, topHashes.ToList()));
    }
}