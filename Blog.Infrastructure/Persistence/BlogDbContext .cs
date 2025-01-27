using Blog.Domain.Entities;
using Blog.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistence
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPostEntity> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostEntity>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Author>()
            //    .HasKey(a => a.Id);

            //modelBuilder.Entity<Author>()
            //    .Property(a => a.Name)
            //    .IsRequired();

            //modelBuilder.Entity<Author>()
            //    .Property(a => a.Email)
            //    .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.Email)
                .HasConversion(
                    email => email.ToString(),
                    value => new Email(value)
                );
        }
    }
}