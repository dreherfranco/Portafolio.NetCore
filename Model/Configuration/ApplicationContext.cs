using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configuration
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.User_Id);

            modelBuilder.Entity<Post>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Posts)
               .HasForeignKey(p => p.Category_Id);
        }
    }
}
