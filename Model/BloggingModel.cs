using System.Collections.Generic;
namespace EFGetStartedMySQL
{
  public class Post
  {
      
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public virtual  Blog Blog { get; set; }
  }

   public class Blog
  {
    public int BlogId { get; set; }
    public string Url { get; set; }
    public virtual ICollection<Post> Posts { get; set; }

  }
}