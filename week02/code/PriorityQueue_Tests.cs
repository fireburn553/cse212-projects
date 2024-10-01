using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The queue is empty
    // Expected Result: InvalidOperationException, the queue is empty
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyQueue()
    {

        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Add items with mixed priorities and ensure the Dequeue() function will always retrieve the highest priority item.
    // Expected Result: "C"
    // Defect(s) Found: 
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", -10);
        priorityQueue.Enqueue("B", -2);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 1);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("C", result);
    }

    // Add more test cases as needed below.
    [TestMethod]
    //Scenario: Add items with same priority and ensure the Dequeue() function will follow the FIFO behavior for the items with the same priority
    //Expected Result: "B", then "E"
    //Defect(s) Found:
    public void TestPriorityQueue_SamePriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 5);

        var firstResult = priorityQueue.Dequeue();
        var secondResult = priorityQueue.Dequeue(); //Checking if the FIFO Behavior is working

        Assert.AreEqual("B", firstResult); //Highest priority first
        Assert.AreEqual("E", secondResult);//FIFO for the same priority
    }
}