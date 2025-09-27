using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        List<Video> videos = new List<Video>();
        
        // Video 1 Section - 
        Video video1 = new Video("C# Basics for Beginners", "Microsoft", 1800);
        video1.AddComment(new Comment("Programmer1", "Great explanation of classes!"));
        video1.AddComment(new Comment("Coder4U", "This helped me a lot with my project."));
        video1.AddComment(new Comment("CSharpFan", "Love the examples. Thank you!"));
        videos.Add(video1);

        // Video 2 Section - 
        Video video2 = new Video("Introduction to OOP", "LearnCode", 1250);
        video2.AddComment(new Comment("DevGirl", "The concepts are so clear now."));
        video2.AddComment(new Comment("CodeMaster", "Can you make a video about inheritance next?"));
        video2.AddComment(new Comment("TechNerd", "Very well-paced and easy to follow."));
        videos.Add(video2);

        // Video 3 Section - 
        Video video3 = new Video("Web Development 101", "WebWizards", 2500);
        video3.AddComment(new Comment("WebLearner", "Finally, a simple guide to HTML!"));
        video3.AddComment(new Comment("PixelPusher", "This is a great starting point."));
        video3.AddComment(new Comment("DesignGuru", "Looking forward to more videos on CSS."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
        }
    }
}