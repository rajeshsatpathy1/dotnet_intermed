using System;
using System.Threading;

public class Stopwatch
{
    private DateTime _startTime;
    private DateTime _endTime;
    private bool _running;

    public void Start()
    {
        // If the stopwatch is already running, throw an exception
        if (_running)
            throw new InvalidOperationException("Stopwatch is already running.");

        _startTime = DateTime.Now;
        _running = true;
    }

    public void Stop()
    {
        // If the stopwatch is not running, throw an exception
        if (!_running)
            throw new InvalidOperationException("Stopwatch is not running.");

        _endTime = DateTime.Now;
        _running = false;
    }

    public TimeSpan GetDuration()
    {
        // If the stopwatch is running, throw an exception
        if (_running)
            throw new InvalidOperationException("Stopwatch is still running.");

        return _endTime - _startTime;
    }
}

public class Program
{
	public static void Main()
    {
        var stopwatch = new Stopwatch();

        // Test 1: Normal usage
        Console.WriteLine("Test 1: Normal usage");
        stopwatch.Start();
        Thread.Sleep(1000); // Wait for 1 second
        stopwatch.Stop();
        Console.WriteLine("Duration: " + stopwatch.GetDuration());
        Console.WriteLine();

        // Test 2: Start the stopwatch twice in a row
        Console.WriteLine("Test 2: Start the stopwatch twice in a row");
        try
        {
            stopwatch.Start();
            stopwatch.Start(); // This should throw an exception
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine();

        // Test 3: Stop the stopwatch twice in a row
        Console.WriteLine("Test 3: Stop the stopwatch twice in a row");
        try
        {
            stopwatch.Stop();
            stopwatch.Stop(); // This should throw an exception
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine();

        // Test 4: Get the duration while the stopwatch is running
        Console.WriteLine("Test 4: Get the duration while the stopwatch is running");
        try
        {
            stopwatch.Start();
            Console.WriteLine("Duration: " + stopwatch.GetDuration()); // This should throw an exception
        }
        catch (InvalidOperationException e)
		{
			Console.WriteLine(e.Message);
		}
		finally
		{
			stopwatch.Stop();
		}
        Console.WriteLine();

        // Test 5: Use the stopwatch multiple times
        Console.WriteLine("Test 5: Use the stopwatch multiple times");
        stopwatch.Start();
        Thread.Sleep(1000); // Wait for 1 second
        stopwatch.Stop();
        Console.WriteLine("Duration: " + stopwatch.GetDuration());
        stopwatch.Start();
        Thread.Sleep(2000); // Wait for 2 seconds
        stopwatch.Stop();
        Console.WriteLine("Duration: " + stopwatch.GetDuration());
        Console.WriteLine();
	}
}