using homework10WEB_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace homework10WEB_API.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Film> Films { get; set; }
}
