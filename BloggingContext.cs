using Microsoft.EntityFrameworkCore;
using EFGetStartedMySQL;

namespace EFGetStartedMySQL
{
  public class BloggingContext : DbContext
  {
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts  { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=localhost;database=Blogging;user=root;password=root");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      //Constructor de objectos
      modelBuilder.Entity<Blog>(entity =>
      {
        entity.HasKey(b => b.BlogId);
        entity.Property(b => b.Url).IsRequired();
      });
      modelBuilder.Entity<Post>(entity =>
      {
        entity.HasKey(p => p.PostId);
        entity.Property(p => p.Title).IsRequired();
        entity.Property(p => p.Content).IsRequired();
        entity.Property(p => p.BlogId).IsRequired();
        entity.HasOne(l => l.Blog)
          .WithMany(d => d.Posts);
      });
    }
  }
}
