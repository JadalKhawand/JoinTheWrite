using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using JoinTheWrite.Models;
using JoinTheWrite.Models.enums;

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
            modelBuilder.Entity<Chapter>()
               .Property(c => c.Status)
               .HasConversion(
                   v => v.ToString(),   
                   v => (WritingStatus)Enum.Parse(typeof(WritingStatus), v)  
               );
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Author)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Contribution)
                .WithMany(c => c.Votes)
                .HasForeignKey(v => v.ContributionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Creation>()
                .HasOne(c => c.Author)
                .WithMany(u => u.Creations)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // Keep this one!

            modelBuilder.Entity<Chapter>()
                .HasOne(c => c.Creation)
                .WithMany(cr => cr.Chapters)
                .HasForeignKey(c => c.CreationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chapter>()
                .HasOne(c => c.FinalizedContribution)
                .WithMany()
                .HasForeignKey(c => c.FinalizedContributionId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Creation>()
                .HasMany(c => c.Chapters)
                .WithOne(ch => ch.Creation)
                .HasForeignKey(ch => ch.CreationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chapter>()
                .HasOne(c => c.FinalizedContribution)
                .WithMany()
                .HasForeignKey(c => c.FinalizedContributionId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Creation>()
                .HasOne(c => c.Author)
                .WithMany(u => u.Creations)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Contribution)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ContributionId)
                .OnDelete(DeleteBehavior.NoAction); 


        }


    }
}
