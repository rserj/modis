namespace Modis.Twitter.Domain.Service;

using System.Text.RegularExpressions;

public class HashTagCounter
{
    /// <summary>
    /// Compiled regex, which is matching #tags in a tweet
    /// </summary>
    //private Regex _hashMatch = new Regex("(?<tag>#[a-z0-9_]+)", RegexOptions.Compiled);
    private Regex _hashMatch = new Regex(@"\W(\#[a-zA-Z]+\b)(?!;)", RegexOptions.Compiled);
    public IEnumerable<string> Count(string tweetText)
    {
        var match = this._hashMatch.Matches(tweetText);

        foreach (var hash in this._hashMatch.Matches(tweetText))
        {
            if (!string.IsNullOrWhiteSpace(hash.ToString()))
                yield return hash.ToString()!.Trim();
        }

    }
}