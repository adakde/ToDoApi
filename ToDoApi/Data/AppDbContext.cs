using Microsoft.EntityFrameworkCore;
using ToDoApi.Entity;
namespace ToDoApi.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Entity.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity.Task>()
                .Property(t => t.Id)
                .IsRequired();
            modelBuilder.Entity<Entity.Task>()
                .Property(v => v.Title)
                .IsRequired();
            modelBuilder.Entity<Entity.Task>()
                .Property(v => v.Description)
                .HasMaxLength(255);
            modelBuilder.Entity<Entity.Task>()
                .Property(v => v.CreatedAt)
                .HasDefaultValueSql("getdate()");
        }
    }

}

