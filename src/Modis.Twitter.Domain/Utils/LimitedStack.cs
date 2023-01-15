namespace Modis.Twitter.Domain.Utils;

public class LimitedStack<T>
{
    private readonly int _hardCapacity;

    private List<T> _items = new List<T>();

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="hardCapacity">
    /// Hard threshold to maintain a Stack of provided size
    /// </param>
    public LimitedStack(int hardCapacity)
    {
        _hardCapacity = hardCapacity;
    }

    public int Coun => this._items.Count;
    public void Push(T item)
    {
        _items.Add(item);
        EnsureCapacity();
    }

    public void Remove(T item)
    {
        if (this._items.Count > 0)
        {
            this._items.Remove(item);
        }
    }


    public bool TryPeek(out T val)
    {
        if (this._items.Count > 0)
        {
            val=_items[this._items.Count - 1];
            return true;
        }
        val = default;
        return false;
    }


    private void EnsureCapacity()
    {
        var toRemove = this._items.Count - this._hardCapacity;
        if (toRemove > 0) // check if capacity exceeded
            _items.RemoveRange(0, toRemove);
    }

    public IEnumerable<T> List()
    {
        return _items;
    }
}