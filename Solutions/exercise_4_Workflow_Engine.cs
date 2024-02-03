using System;
using System.Collections.Generic;
using System.Linq;

public interface IActivity
{
    void Execute();
}

public class UploadVideo : IActivity
{
    public void Execute()
    {
        Console.WriteLine("Uploading video to cloud storage...");
    }
}

public class CallWebService : IActivity
{
    public void Execute()
    {
        Console.WriteLine("Calling web service to encode video...");
    }
}

public class SendEmail : IActivity
{
    public void Execute()
    {
        Console.WriteLine("Sending email to video owner...");
    }
}

public class ChangeDatabaseStatus : IActivity
{
    public void Execute()
    {
        Console.WriteLine("Changing video status in database to 'Processing'...");
    }
}

public class Workflow
{
    private readonly List<IActivity> _activities;

    public Workflow()
    {
        _activities = new List<IActivity>();
    }

    public void Add(IActivity activity)
    {
        _activities.Add(activity);
    }

    public IEnumerable<IActivity> GetActivities()
    {
        return _activities;
    }
}

public class WorkflowEngine
{
    public void Run(Workflow workflow)
    {
        var activities = workflow.GetActivities();
        if (!activities.Any())
        {
            Console.WriteLine("No activities to execute in this workflow.");
            return;
        }

        foreach (var activity in activities)
        {
            activity.Execute();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var workflow1 = new Workflow();
        workflow1.Add(new UploadVideo());
        workflow1.Add(new CallWebService());
        workflow1.Add(new SendEmail());
        workflow1.Add(new ChangeDatabaseStatus());

        var engine = new WorkflowEngine();
        Console.WriteLine("Running workflow 1:");
        engine.Run(workflow1);

        var workflow2 = new Workflow();
        workflow2.Add(new UploadVideo());
        workflow2.Add(new SendEmail());

        Console.WriteLine("\nRunning workflow 2:");
        engine.Run(workflow2);

        var workflow3 = new Workflow();

        Console.WriteLine("\nRunning workflow 3:");
        engine.Run(workflow3);
    }
}
