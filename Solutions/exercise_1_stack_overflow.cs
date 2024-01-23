using System;
using System.Collections.Generic;

public class Post
{
    // Properties
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; private set; }
    private int _votes;

    // Constructor
    public Post(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedAt = DateTime.Now;
        _votes = 0;
    }

    // Methods
    public void Upvote()
    {
        _votes++;
    }

    public void Downvote()
    {
        _votes--;
    }

    public int GetVotes()
    {
        return _votes;
    }
}

public class Program
{
    public static void Main()
    {
        // Create a dictionary to store the posts
        var posts = new Dictionary<int, Post>();

        // Test 1: Create a new post and add it to the dictionary
        Console.WriteLine("Test 1: Create a new post and add it to the dictionary");
        var post1 = new Post(1, "Hello, World!", "This is my first post.");
        posts.Add(post1.Id, post1);
        Console.WriteLine("Added post with Id: " + post1.Id);
        Console.WriteLine();

        // Test 2: Retrieve a post from the dictionary and display its details
        Console.WriteLine("Test 2: Retrieve a post from the dictionary and display its details");
        var retrievedPost = posts[1];
        Console.WriteLine("Title: " + retrievedPost.Title);
        Console.WriteLine("Description: " + retrievedPost.Description);
        Console.WriteLine("Created at: " + retrievedPost.CreatedAt);
        Console.WriteLine("Votes: " + retrievedPost.GetVotes());
        Console.WriteLine();

        // Test 3: Upvote a post and check the vote value
        Console.WriteLine("Test 3: Upvote a post and check the vote value");
        retrievedPost.Upvote();
        Console.WriteLine("Votes: " + retrievedPost.GetVotes());
        Console.WriteLine();

        // Test 4: Downvote a post and check the vote value
        Console.WriteLine("Test 4: Downvote a post and check the vote value");
        retrievedPost.Downvote();
        Console.WriteLine("Votes: " + retrievedPost.GetVotes());
        Console.WriteLine();

        // Test 5: Upvote and downvote a post multiple times and check the vote value
        Console.WriteLine("Test 5: Upvote and downvote a post multiple times and check the vote value");
        retrievedPost.Upvote();
        retrievedPost.Upvote();
        retrievedPost.Downvote();
        retrievedPost.Upvote();
        retrievedPost.Downvote();
        retrievedPost.Downvote();
        Console.WriteLine("Votes: " + retrievedPost.GetVotes());
        Console.WriteLine();
    }
}