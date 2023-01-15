namespace Modis.TwitterClient
{
    using System.Runtime.CompilerServices;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using Modis.TwitterClient.Abstractions;
    using Modis.TwitterClient.Abstractions.Model;
    using Newtonsoft.Json.Linq;
    using ITwitterClient = Modis.TwitterClient.Abstractions.ITwitterClient;

    internal class TwitterClient : ITwitterClient
    {
        private const string HttpAuthorizationHeaderName = "Authorization";
        private readonly IOptions<TwitterSettings> _options;
        private readonly ILogger<TwitterClient> _logger;

        public TwitterClient(IOptions<TwitterSettings> options, ILogger<TwitterClient> logger)
        {
            this._options = options;
            this._logger = logger;
        }

        public async IAsyncEnumerable<Twit> GetTweetStream([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(HttpAuthorizationHeaderName, new[] { $"Bearer {this._options.Value.BearToken}" });

            var streamResp = await httpClient.GetStreamAsync(this._options.Value.StreamUrl, cancellationToken);
            using (var reader = new StreamReader(streamResp))
            {
                while (!reader.EndOfStream)
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    var tweetJson = await reader.ReadLineAsync();
                    if (!string.IsNullOrEmpty(tweetJson))
                    {
                        JToken jTweet = JToken.Parse(tweetJson);
                        yield return jTweet["data"]!.ToObject<Twit>()!;
                    }
                }
            }
        }
    }
}