using BlogApp.Model.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DAL
{
    public class BlogAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Database=BlogAppDotNetCore; Trusted_Connection=True;",
                builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Post> Post { get; set; }


        // protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
