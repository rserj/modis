namespace Modis.Twitter.Domain.Abstractions;
public interface ITwitterStreamWorker
{
    /// <summary>
    /// Watches top #10 tweet hash-tags
    /// </summary>
    /// <param name="cts"></param>
    void WatchTwitterStream(CancellationToken cts);
}
