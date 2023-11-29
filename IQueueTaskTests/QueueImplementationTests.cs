using IQueueTask.Core;

namespace IQueueTaskTests;

public class QueueImplementationTests
{
    [Fact]
    public void Enqueue_AddsElementToQueue()
    {
        // Arrange
        var queue = new QueueImplementation<int>();
        var element = 42;

        // Act
        queue.Enqueue(element);

        // Assert
        Assert.Equal(1, queue.QueueImplementationTests);
        Assert.Equal(element, queue.Peek());
    }

    [Fact]
    public void Dequeue_RemovesAndReturnsFirstElement()
    {
        // Arrange
        var queue = new QueueImplementation<string>();
        queue.Enqueue("foo");
        queue.Enqueue("bar");

        // Act
        var result = queue.Dequeue();

        // Assert
        Assert.Equal("foo", result);
        Assert.Equal(1, queue.QueueImplementationTests);
        Assert.Equal("bar", queue.Peek());
    }

    [Fact]
    public void Peek_ReturnsFirstElementWithoutRemovingIt()
    {
        // Arrange
        var queue = new QueueImplementation<decimal>();
        queue.Enqueue(3.14m);

        // Act
        var result1 = queue.Peek();
        var result2 = queue.Peek();

        // Assert
        Assert.Equal(1, queue.QueueImplementationTests);
        Assert.Equal(3.14m, result1);
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void Dequeue_ThrowsInvalidOperationExceptionIfQueueIsEmpty()
    {
        // Arrange
        var queue = new QueueImplementation<int>();

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Peek_ThrowsInvalidOperationExceptionIfQueueIsEmpty()
    {
        // Arrange
        var queue = new QueueImplementation<string>();

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    [Fact]
    public void Enqueue_ResizeQueueIfCapacityIsReached()
    {
        // Arrange
        var queue = new QueueImplementation<bool>();
        var elementsToAdd = 100;

        // Act
        for (int i = 0; i < elementsToAdd; i++)
        {
            queue.Enqueue(true);
        }

        // Assert
        Assert.Equal(elementsToAdd, queue.QueueImplementationTests);
    }
}