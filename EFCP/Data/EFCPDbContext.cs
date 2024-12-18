using EFCP.Data.ModelConfigurations;
using EFCP.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.Data
{
    public class EFCPDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        //This is already Configured In Book Model.
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFCPractice;Trusted_Connection=True;ConnectRetryCount=0");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Fluent API to Configure a model.
            //modelBuilder.Entity<Blog>()
            //    .Property(b => b.Url)
            //    .IsRequired();

            //Or We can Configure it Like this to seperate configuration files.
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());

            //Or we can configure it like this.
            //modelBuilder.Entity<Book>();
            //modelBuilder.Entity<User>();

        }
    }
}