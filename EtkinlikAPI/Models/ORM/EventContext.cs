using Microsoft.EntityFrameworkCore;

namespace EtkinlikAPI.Models.ORM
{
    public class EventContext : DbContext
    {
        //seed data on model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Yazılım", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Teknoloji", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Eğitim", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Sağlık", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Spor", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Sanat", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Müzik", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Eğlence", AddDate = DateTime.Now, IsDeleted = false });
            modelBuilder.Entity<Category>().HasData(new Category { Id = Guid.NewGuid(), Name = "Diğer", AddDate = DateTime.Now, IsDeleted = false });
        }

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityImages> ActivityImages { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }

    }
}
