using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineGameStoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace OnlineGameStoreDAL.Context
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres{ get; set; }

        public StoreDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.Entity<Game>().HasAlternateKey(g => g.Key); // Can be wrong!!!!
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            modelBuilder.Entity<Publisher>().HasAlternateKey(g => g.Key); // Can be wrong!!!!
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.Entity<Publisher>().HasAlternateKey(g => g.Name); // Can be wrong!!!!
        }

        public class GameConfiguration : IEntityTypeConfiguration<Game>
        {
            public void Configure(EntityTypeBuilder<Game> builder)
            {
                builder.ToTable("Games").HasKey(g => g.Id);
                builder.Property(p => p.Key).IsRequired().HasMaxLength(50);
                builder.Property(p => p.Name).IsRequired().HasMaxLength(40);
                builder.Property(p => p.Description).HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
            }
        }
        public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
        {
            public void Configure(EntityTypeBuilder<Publisher> builder)
            {
                builder.ToTable("Publishers").HasKey(g => g.Id);
                builder.Property(p => p.Key).IsRequired().HasMaxLength(50);
                builder.Property(p => p.Name).IsRequired().HasMaxLength(40);
            }
        }

        public class CommentConfiguration : IEntityTypeConfiguration<Comment>
        {
            public void Configure(EntityTypeBuilder<Comment> builder)
            {
                builder.ToTable("Comments").HasKey(g => g.Id);
                builder.Property(c => c.Name).IsRequired().HasMaxLength(40);
                builder.Property(c => c.Body).IsRequired();
            }
        }

        public class GenreConfiguration : IEntityTypeConfiguration<Genre>
        {
            public void Configure(EntityTypeBuilder<Genre> builder)
            {
                builder.ToTable("Genres").HasKey(g => g.Id);
                builder.Property(c => c.Name).IsRequired().HasMaxLength(40);
            }
        }

        public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
        {
            public void Configure(EntityTypeBuilder<GameGenre> builder)
            {
                builder.ToTable("GameGenres").HasKey(gg => new { gg.GameId, gg.GenreId });
            }
        }
    }
}
