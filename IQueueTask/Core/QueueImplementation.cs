namespace IQueueTask.Core;

public class QueueImplementation<T> : IQueue<T>
{
    private T?[] _queue = Array.Empty<T>();
    private int _last = -1;
    public int QueueImplementationTests => _last + 1;

    public void Enqueue(T? element)
    {
        if (_queue.Length - 1 == _last)
        {
            ReSize();
        }

        _last++;
        _queue[_last] = element;
    }

    public T? Dequeue()
    {
        if (_last == -1)
        {
            throw new InvalidOperationException("Queue is Empty");
        }
        
        var result = _queue[0];
        for (int i = 0; i < _queue.Length - 1; i++)
        {
            _queue[i] = _queue[i + 1];
        }

        _queue[_last] = default;
        _last--;
        return result;
    }

    public T? Peek()
    {
        if (_last == -1)
        {
            throw new InvalidOperationException("Queue is Empty");
        }

        return _queue[0];
    }
    
    private void ReSize()
    {
        var lenght = _queue.Length;
        if (lenght == 0)
        {
            _queue = new T[1];
        }
        else
        {
            T?[] newQueue = new T[lenght * 2];
            for (int i = 0; i < lenght; i++)
            {
                newQueue[i] = _queue[i];
            }

            _queue = newQueue;
        }
    }
}