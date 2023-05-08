using BlogSayt.Model;
using BlogSayt.Model.Blog;
using BlogSayt.Model.Topic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSayt.DAL
{
    internal class MyContent : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CA-R215-PC06\SQLEXPRESS;Database=AdeNot; Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(
                model =>
                {
                    model.HasKey(prop => prop.Id);
                    model.Property(prop => prop.Title).HasMaxLength(50).IsRequired(true);
                    model.Property(prop => prop.AuthorId).IsRequired(true);

                });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Topic>(
                topic =>
                {
                    topic.HasKey(prop => prop.Id);
                    topic.Property(prop => prop.Title).HasMaxLength(50).IsRequired(true);
                    topic.Property(prop => prop.ParentTopicId).IsRequired(false);

                });
            base.OnModelCreating(modelBuilder);
        }

    }
}
