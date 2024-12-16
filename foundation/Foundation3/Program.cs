using System;
using System.Collections.Generic;

// Base class for all activities
public abstract class Activity
{
    // Shared attributes for all activities
    protected DateTime activityDate;
    protected int durationInMinutes; // Duration in minutes

    // Constructor
    public Activity(DateTime date, int duration)
    {
        activityDate = date;
        durationInMinutes = duration;
    }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Method to get the summary information
    public string GetSummary()
    {
        return $"{activityDate.ToString("dd MMM yyyy")} {this.GetType().Name} ({durationInMinutes} min) - Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double distance; // Distance in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / durationInMinutes) * 60;

    public override double GetPace() => durationInMinutes / distance;
}

// Derived class for Stationary Bicycle
public class Cycling : Activity
{
    private double speed; // Speed in miles per hour

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * durationInMinutes) / 60;

    public override double GetSpeed() => speed;

    public override double GetPace() => 60 / speed;
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int laps; // Number of laps swum

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance() => (laps * 50) / 1000.0; // Convert to kilometers

    public override double GetSpeed() => (GetDistance() / durationInMinutes) * 60; // Speed in km/h

    public override double GetPace() => durationInMinutes / GetDistance(); // Pace in min per km
}

// Program class to demonstrate the usage
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0), // Running 3 miles in 30 minutes
            new Cycling(new DateTime(2022, 11, 3), 30, 18.0), // Cycling at 18 mph for 30 minutes
            new Swimming(new DateTime(2022, 11, 3), 30, 20) // Swimming 20 laps in 30 minutes
        };

        // Iterate through the list and display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
