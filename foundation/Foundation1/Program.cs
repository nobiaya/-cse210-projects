using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Exploring C# Basics", "TechTalk", 600);
        Video video2 = new Video("Top 10 Programming Tips", "CodeMaster", 480);
        Video video3 = new Video("Introduction to Machine Learning", "AI Wizard", 720);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great explanation, very clear!"));
        video1.AddComment(new Comment("Bob", "Loved the examples."));
        video1.AddComment(new Comment("Charlie", "Can you make a tutorial on advanced topics?"));

        // Add comments to video2
        video2.AddComment(new Comment("Dave", "Very helpful tips!"));
        video2.AddComment(new Comment("Eve", "Nice summary, thanks!"));
        video2.AddComment(new Comment("Frank", "Could you include more real-world examples?"));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "This was super helpful!"));
        video3.AddComment(new Comment("Hannah", "I need more on neural networks."));
        video3.AddComment(new Comment("Ivan", "Machine learning is so cool!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display each video's details
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  - {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; }
    public string Author { get; }
    public int Length { get; }
    public List<Comment> Comments { get; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}
