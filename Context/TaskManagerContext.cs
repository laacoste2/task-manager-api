using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Context
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
       
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Id)
                .UseIdentityAlwaysColumn();

            base.OnModelCreating(modelBuilder);
        }

    }
}
