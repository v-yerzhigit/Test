namespace IQueueTask.Core;

public interface IQueue<T>
{
    void Enqueue(T? element);
    T? Dequeue();
    T? Peek();
}