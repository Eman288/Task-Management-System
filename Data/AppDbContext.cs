using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskManagementSystem.Models.Task>()
                .HasKey(t => t.TaskID);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskManagementSystem.Models.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
