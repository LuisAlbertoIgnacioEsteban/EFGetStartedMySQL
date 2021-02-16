using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace EFGetStartedMySQL
{
   class Program
  {
    static void Main(string[] args)
    {
      InsertData();
      PrintData();
    }

    private static void InsertData()
    {
      using(var context = new BloggingContext())
      {
        // Creates the database if not exists
        context.Database.EnsureCreated();

        // Add a blog
        var blog = new Blog
        {
          BlogId = 1,
          Url = "http://blogs.msdn.com/adonet"
        };
        context.Blogs.Add(blog);

        // Adds some pots
        context.Posts.Add(new Post
        {
            PostId = 1,
            Title = "Hello World",
            Content = "I wrote an app using EF Core!",
            BlogId = blog.BlogId,
            Blog = blog
        });
        context.Posts.Add(new Post
        {
            PostId = 2,
            Title = "Hello World 2",
            Content = "I wrote an app using EF Core!",
            BlogId = blog.BlogId,
            Blog = blog
        });

        // Saves changes
        context.SaveChanges();
      }
    }

    private static void PrintData()
    {
      // Gets and prints all books in database
      using (var context = new EFGetStartedMySQL.BloggingContext())
      {
        var posts = context.Posts.Include(b => b.Blog);
        foreach(var post in posts)
        {
          var data = new StringBuilder();
          data.AppendLine($"PostId: {post.PostId}");
          data.AppendLine($"Title: {post.Title}");
          data.AppendLine($"Content: {post.Content}");
          data.AppendLine($"BlogId: {post.BlogId}");
          data.AppendLine($"Blog: {post.Blog.Url}");
          Console.WriteLine(data.ToString());
        }
      }
    }
  }
}