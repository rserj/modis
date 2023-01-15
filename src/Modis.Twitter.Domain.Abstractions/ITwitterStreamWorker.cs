namespace Modis.Twitter.Domain.Abstractions;
public interface ITwitterStreamWorker
{
    void WatchTwitterStream(CancellationToken cts);
}
