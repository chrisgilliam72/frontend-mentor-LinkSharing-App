using LinkSharingRepository.Models;
using Microsoft.EntityFrameworkCore;
namespace LinkSharingRepository;


public class SQLiteContext : DbContext
{
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CustomLink> CustomLinks { get; set; }  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var location = AppDomain.CurrentDomain.BaseDirectory;
        optionsBuilder.UseSqlite("Data Source=LinkSharing.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Platform>().HasData(new Platform { Id = 1, Name="Stack Overflow",Icon= "icon-stack-overflow.svg" },
                                                new Platform { Id = 2, Name = "You Tube", Icon = "icon-youtube.svg" },
                                                new Platform { Id = 3, Name = "GitHub", Icon = "icon-gitlab.svg" },
                                                new Platform { Id = 4, Name = "Facebook", Icon = "icon-facebook.svg" },
                                                new Platform { Id = 5, Name = "Twitter", Icon = "icon-twitter.svg" },
                                                new Platform { Id = 6, Name = "Free Code Camp", Icon = "icon-freecodecamp.svg" },
                                                new Platform { Id = 7, Name = "Twitch", Icon = "icon-twitch.svg" });
    }
}
