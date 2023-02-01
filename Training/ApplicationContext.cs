using Microsoft.EntityFrameworkCore;
namespace Training
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions options) : base(options) 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Tom", Age = 32 },
                new User { Id = 2, Name = "Bob", Age = 47 },
                new User { Id = 3, Name = "Sam", Age = 28 });
        }
    }
}
