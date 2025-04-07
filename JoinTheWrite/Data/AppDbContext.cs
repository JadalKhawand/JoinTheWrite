using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using JoinTheWrite.Models;

namespace JoinTheWrite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Creation> Creations { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.User)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Contribution)
                .WithMany(c => c.Votes)
                .HasForeignKey(v => v.ContributionId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
