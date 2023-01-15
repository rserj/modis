namespace Modis.Tests
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;

    using Modis.Tests.Mocks;
    using Modis.TwitterClient.Abstractions;
    using Modis.TwitterClient.Abstractions.Model;

    using Moq;

    // Not ready yet
    public class TwitterStreamWorkerTests
    {
        /// <summary>
        /// The Mock data.
        /// #3d - 10, #avatar - 6, #sky - 4, #newyear - 6, #tea - 8
        /// #topPop - 2, #saveWater - 1, #electro - 3, #anime - 2, #rain - 4, #snp500 - 1, #air - 3, #android - 3, #xamarintvos - 3
        /// </summary>
        private Tweet[] _mockData = {
                                        new Tweet { Id = "1", Text = "testing #avatar #3d" },
                                        new Tweet { Id = "1", Text = "bad weather #rain" },
                                        new Tweet { Id = "1", Text = "#avatar #3d" },
                                        new Tweet { Id = "1", Text = "market #snp500 #sky #3d" },
                                        new Tweet { Id = "1", Text = "testing #avatar #3d #android" },
                                        new Tweet { Id = "1", Text = "#music2023 #tea #tea" },
                                        new Tweet { Id = "1", Text = "testing #avatar #3d" },
                                        new Tweet { Id = "1", Text = "movie #3d #tea #air session" },
                                        new Tweet { Id = "1", Text = "testing #avatar #3d" },
                                        new Tweet { Id = "1", Text = "#newyear #tea #tea" },
                                        new Tweet { Id = "1", Text = "#topPop #3d #xamarintvos" },
                                        new Tweet { Id = "1", Text = "#rain #saveWater" },
                                        new Tweet { Id = "1", Text = "#anime #sky #3d #android" },
                                        new Tweet { Id = "1", Text = "testing #tea #avatar #3d" },
                                        new Tweet { Id = "1", Text = "#newyear #air #xamarintvos" },
                                        new Tweet { Id = "1", Text = "#sky #sky #rain   #android" },
                                        new Tweet { Id = "1", Text = "#coffee #electro" },
                                        new Tweet { Id = "1", Text = "#electro #newyear #newyear" },
                                        new Tweet { Id = "1", Text = "#topPop" },
                                        new Tweet { Id = "1", Text = "#newyear #xamarintvos" },
                                        new Tweet { Id = "1", Text = "#anime #tea" },
                                        new Tweet { Id = "1", Text = "#electro #tea" },
                                        new Tweet { Id = "1", Text = "#newyear #rain" },
                                        new Tweet { Id = "1", Text = "#air " },
                                    };
        [Fact]
        public void Valid_TwitterCount()
        {
            var streamWorkerMock = this.GetSystemUnderTest().GetRequiredService<TwitterStreamWorkerMock>();
            streamWorkerMock.WatchTwitterStream(CancellationToken.None);
            // TODO test for streamWorkerMock.PrintData content
        }


        public ServiceProvider GetSystemUnderTest()
        {
            var twitterClientMock = new Mock<ITwitterClient>(MockBehavior.Strict);
            twitterClientMock.Setup(client => client.GetTweetStream(It.IsAny<CancellationToken>())).Returns(() => this._mockData.ToAsyncEnumerable());

            var services = new ServiceCollection();
            services
                .AddLogging()
                .AddMemoryCache()
                .AddTransient<ITwitterClient>(provider => twitterClientMock.Object)
                .AddTransient<TwitterStreamWorkerMock>();
            return services.BuildServiceProvider();
        }
    }
}