using FUNewsManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SystemAccount> SystemAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Tag> Tags { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemAccount>()
                .HasIndex(a => a.Email)
                .IsUnique();

            modelBuilder.Entity<SystemAccount>()
                .HasMany(a => a.NewsArticles)
                .WithOne(n => n.SystemAccount)
                .HasForeignKey(n => n.SystemAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.NewsArticles)
                .WithOne(n => n.Category)
                .HasForeignKey(n => n.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NewsArticle>()
                .HasMany(n => n.Tags)
                .WithOne(t => t.NewsArticle)
                .HasForeignKey(t => t.NewsArticleId)
                .OnDelete(DeleteBehavior.SetNull);
        }*/
    }

}
