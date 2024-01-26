// This code was AI generated

using System;
using System.Collections.Generic;

public class Stack
{
    private readonly LinkedList<object> _elements = new LinkedList<object>();

    public void Push(object obj)
    {
        if (obj == null)
            throw new InvalidOperationException("You cannot add a null object to the stack.");

        _elements.AddLast(obj);
    }

    public object Pop()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("No elements in the stack to pop.");

        var lastElement = _elements.Last.Value;
        _elements.RemoveLast();

        return lastElement;
    }

    public void Clear()
    {
        _elements.Clear();
    }
}

public class Program
{
    public static void Main()
    {
        var stack = new Stack();

        // Test 1: Push an object to the stack and check the Pop method
        Console.WriteLine("Test 1: Push an object to the stack and check the Pop method");
        stack.Push(1);
        Console.WriteLine(stack.Pop()); // Should print 1
        Console.WriteLine();

        // Test 2: Push multiple objects and check the Pop method
        Console.WriteLine("Test 2: Push multiple objects and check the Pop method");
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine(stack.Pop()); // Should print 3
        Console.WriteLine(stack.Pop()); // Should print 2
        Console.WriteLine(stack.Pop()); // Should print 1
        Console.WriteLine();

        // Test 3: Try to Pop from an empty stack
        Console.WriteLine("Test 3: Try to Pop from an empty stack");
        try
        {
            Console.WriteLine(stack.Pop()); // Should throw an InvalidOperationException
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine();

        // Test 4: Try to Push null to the stack
        Console.WriteLine("Test 4: Try to Push null to the stack");
        try
        {
            stack.Push(null); // Should throw an InvalidOperationException
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine();

        // Test 5: Push and Pop multiple times, then Clear the stack
        Console.WriteLine("Test 5: Push and Pop multiple times, then Clear the stack");
        stack.Push(1);
        stack.Push(2);
        Console.WriteLine(stack.Pop()); // Should print 2
        stack.Push(3);
        Console.WriteLine(stack.Pop()); // Should print 3
        stack.Clear();
        try
        {
            Console.WriteLine(stack.Pop()); // Should throw an InvalidOperationException
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine();
    }
}
