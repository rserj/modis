namespace Modis.Twitter.Domain.Utils;

using System.Text.RegularExpressions;

internal static class HashTagParser
{
    /// <summary>
    /// Compiled regex, for matching #tags in a tweet
    /// </summary>
    private static Regex _hashMatch = new Regex(@"\W(\#[a-zA-Z]+\b)(?!;)", RegexOptions.Compiled);
    public static IEnumerable<string> GetTweetTags(string tweetText)
    {
        var match = _hashMatch.Matches(tweetText);

        foreach (var hash in _hashMatch.Matches(tweetText))
        {
            if (!string.IsNullOrWhiteSpace(hash.ToString()))
                yield return hash.ToString()!.Trim();
        }

    }
}