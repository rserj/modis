namespace Modis.Tests;

using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Modis.Tests.Mocks;
using Modis.TwitterClient.Abstractions;
using Moq;

// Not ready yet
public class TwitterStreamWorkerTests
{
    [Fact]
    public void WatchTwitterStream_SimulateStream_ExpectValid_Top10HashTags_TotalTweetsCount()
    {
        var streamWorkerMock = this.GetSystemUnderTest().GetRequiredService<TwitterStreamWorkerMock>();
        streamWorkerMock.WatchTwitterStream(CancellationToken.None);
        streamWorkerMock
            .PrintData
            .First(tags => tags.count == MockData.Tweets.Length)
            .topHashTags
            .Should()
            .Contain(MockData.Top10Tags, "should contain 10 most frequent tags");
    }


    private ServiceProvider GetSystemUnderTest()
    {
        var twitterClientMock = new Mock<ITwitterClient>(MockBehavior.Strict);
        twitterClientMock.Setup(client => client.GetTweetStream(It.IsAny<CancellationToken>())).Returns(() => MockData.Tweets.ToAsyncEnumerable());

        var services = new ServiceCollection();
        services
            .AddLogging()
            .AddMemoryCache()
            .AddTransient(provider => twitterClientMock.Object)
            .AddTransient<TwitterStreamWorkerMock>();
        return services.BuildServiceProvider();
    }
}
