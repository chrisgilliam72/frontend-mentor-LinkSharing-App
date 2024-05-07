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
        modelBuilder.Entity<Platform>().HasData(new Platform { Id = 1, Name="Stack Overflow",Icon= "icon-stack-overflow.svg", BrandingColor = "#f48024" },
                                                new Platform { Id = 2, Name = "You Tube", Icon = "icon-youtube.svg",BrandingColor= "#212121" },
                                                new Platform { Id = 3, Name = "GitHub", Icon = "icon-gitlab.svg", BrandingColor = "#333" },
                                                new Platform { Id = 4, Name = "Facebook", Icon = "icon-facebook.svg",BrandingColor= "#4267B2" },
                                                new Platform { Id = 5, Name = "Twitter", Icon = "icon-twitter.svg", BrandingColor = "#1DA1F2" },
                                                new Platform { Id = 7, Name = "Twitch", Icon = "icon-twitch.svg",BrandingColor = "#9146ff" },
                                                new Platform { Id = 7, Name = "LinkedIn", Icon = "icon-twitch.svg",BrandingColor = "#0a66c2" });
    }
}
