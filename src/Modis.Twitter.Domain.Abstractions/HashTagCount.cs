namespace Modis.Twitter.Domain.Abstractions;

public struct HashTagCount
{
    public readonly string Tag;
    public readonly int Count;

    public HashTagCount(string tag, int count)
    {
        this.Tag = tag;
        this.Count = count;
    }
    
}